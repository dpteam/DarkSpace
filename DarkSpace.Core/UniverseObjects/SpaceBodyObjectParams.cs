namespace DarkSpace.UniverseObjects
{
    class SpaceBodyObjectParams
    {
        public float SpaceBodyObjectDiameterKM { get; set; } = 0f; // Диаметр в килметрах
        public float SpaceBodyObjectMassByE { get; set; } = 0f; // Масса (Земных)
        public float SpaceBodyObjectOrbitalSelfDays { get; set; } = 0f; // Период обращения вокруг себя в земных сутках
        public float SpaceBodyObjectOrbitalDaysStar0 { get; set; } = 0f; // Период обращения вокруг первой звезды в земных сутках
        public float SpaceBodyObjectOrbitalDaysStar1 { get; set; } = 0f; // Период обращения вокруг второй звезды в земных сутках
        public float SpaceBodyObjectOrbitalDaysStar2 { get; set; } = 0f; // Период обращения вокруг третьей звезды в земных сутках
        public float SpaceBodyObjectOrbitalDaysStar3 { get; set; } = 0f; // Период обращения вокруг четвертой звезды в земных сутках
        public float SpaceBodyObjectOrbitalDaysStar4 { get; set; } = 0f; // Период обращения вокруг пятой звезды в земных сутках
        public float SpaceBodyObjectAgeYears { get; set; } = 0f; // Возраст тела в годах
        public float SpaceBodyObjectGravityByE { get; set; } = 0f; // Гравитация (Земных)
        public float SpaceBodyObjectPressureByE { get; set; } = 0f; // Давление атмосферы (Земных)
        public float SpaceBodyObjectTempDegreesCelsius { get; set; } = 0f; // Температура в градусах цельсиях
    }
}
