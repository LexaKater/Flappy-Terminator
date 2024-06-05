public class ScoreZoneSpawner : Spawner<ScoreZone>
{
    protected override void OnGet(ScoreZone scoreZone)
    {
        scoreZone.LifeEnded += OnRelease;
        base.OnGet(scoreZone);
        scoreZone.Init();
    }

    protected override void OnRelease(ScoreZone scoreZone)
    {
        scoreZone.LifeEnded -= OnRelease;
        base.OnRelease(scoreZone);
    }
}
