public class CloudSpawner : Spawner<Cloud>
{
    protected override void OnGet(Cloud cloud)
    {
        cloud.LifeEnded += OnRelease;
        base.OnGet(cloud);
        cloud.Init();
    }

    protected override void OnRelease(Cloud cloud)
    {
        cloud.LifeEnded -= OnRelease;
        base.OnRelease(cloud);
    }
}