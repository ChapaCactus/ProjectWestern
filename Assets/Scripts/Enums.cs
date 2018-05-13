namespace CCG.Enums
{
    public enum Direction2D
    {
        None = -1,

        DownLeft = 1,
        Down = 2,
        DownRight = 3,
        Left = 4,
        Neutral = 5,
        Right = 6,
        UpLeft = 7,
        Up = 8,
        UpRight = 9,
    }

    public enum Direction
    {
        None,

        North,
        South,
        West,
        East,
    }

    public enum StageID
    {
        None = -1,
		Stage001 = 1,
		Stage002,
		Stage003,
    }

    public enum SceneName
    {
        Title,
        StageSelect,
        Stage,
    }

    public enum ItemID
    {
        None = -1,
        Gold1 = 0,
        Gold3,
        Gold5,
        Gold10,
        Gold50,
        Gold100,
    }

    public enum EnemyAIType
    {
        None = -1,
        Normal = 0,
    }

    public enum GunID
    {
        None = -1,

        Gun001 = 0,
    }

    public enum GunShootType
    {
        None = -1,
        OneWay = 0,
    }

    public enum BulletID
    {
        None = -1,

        Bullet001,
        Bullet002,
        Bullet003,
        Bullet004,
        Bullet005,
    }
}