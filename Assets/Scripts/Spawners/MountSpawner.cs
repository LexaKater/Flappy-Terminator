public class MountSpawner : Spawner<Mount>
{
    protected override void OnGet(Mount mount)
    {
        mount.LifeEnded += OnRelease;
        base.OnGet(mount);
        mount.Init();
    }

    protected override void OnRelease(Mount mount)
    {
        mount.LifeEnded -= OnRelease;
        base.OnRelease(mount);
    }
}