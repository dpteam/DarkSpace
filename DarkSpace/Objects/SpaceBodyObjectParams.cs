using System;
using System.Collections.Generic;
using System.Text;

namespace DarkSpace.Objects
{
    class SpaceBodyObjectParams
    {
        public float objDiameterKM = 0f; // Диаметр в килметрах
        public float objMassByE = 0f; // Масса (Земных)
        public float objOrbitalSelfDays = 0f; // Период обращения вокруг себя в земных сутках
        public float objOrbitalDaysStar0 = 0f; // Период обращения вокруг первой звезды в земных сутках
        public float objOrbitalDaysStar1 = 0f; // Период обращения вокруг второй звезды в земных сутках
        public float objOrbitalDaysStar2 = 0f; // Период обращения вокруг третьей звезды в земных сутках
        public float objOrbitalDaysStar3 = 0f; // Период обращения вокруг четвертой звезды в земных сутках
        public float objOrbitalDaysStar4 = 0f; // Период обращения вокруг пятой звезды в земных сутках
        public float objAgeYears = 0f; // Возраст тела в годах
        public float objGravityByE = 0f; // Гравитация (Земных)
        public float objPressureByE = 0f; // Давление атмосферы (Земных)
        public float objTempDegreesCelsius = 0f; // Температура в градусах цельсиях
    }
}
