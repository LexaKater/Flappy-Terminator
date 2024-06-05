public class BulletSpawner : Spawner<Bullet>
{
    protected override void OnGet(Bullet bullet)
    {
        bullet.LifeEnded += OnRelease;
        base.OnGet(bullet);
        bullet.Init();
    }

    protected override void OnRelease(Bullet bullet)
    {
        bullet.LifeEnded -= OnRelease;
        base.OnRelease(bullet);
    }

    public void Init() => StartCoroutine(StartCreate());
}
