using System.Collections.Generic;

namespace PhysicsCalculator
{
    public class DerivedMeasure
    {
        private readonly SIMeasuresList _siMeasuresList = new SIMeasuresList();

        public Measure Radian
        {
            get
            {
                var dictionary = new Dictionary<Measure, int> {{_siMeasuresList.Metre, 1}, {_siMeasuresList.Metre, -1}};
                return new Measure("Radian", dictionary);
            }
        }

        public Measure Steradian
        {
            get
            {
                var dictionary = new Dictionary<Measure, int> {{_siMeasuresList.Metre, 2}, {_siMeasuresList.Metre, -2}};
                return new Measure("Steradian", dictionary);
            }
        }

        public Measure DegreeCelsius
        {
            get
            {
                var dictionary = new Dictionary<Measure, int> {{_siMeasuresList.Kelvin, 1}};
                return new Measure("DegreeCelsius", dictionary);
            }
        }

        public Measure Hertz
        {
            get
            {
                var dictionary = new Dictionary<Measure, int> {{_siMeasuresList.Second, 1}};
                return new Measure("Hertz", dictionary);

            }
        }

        public Measure Newton
        {
            get
            {
                var dictionary = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Kilogram, 1},
                    {_siMeasuresList.Metre, 1},
                    {_siMeasuresList.Second, -2}
                };
                return new Measure("Newton", dictionary);
            }
        }

        public Measure Joule
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Kilogram, 1},
                    {_siMeasuresList.Metre, 2},
                    {_siMeasuresList.Second, -2}
                };
                var dictionaryEquivalent = new Dictionary<Measure, int> {{Newton, 1}, {_siMeasuresList.Metre, 1}};
                return new Measure("Joule", dictionaryEquivalent, dictionarySi);
            }
        }

        public Measure Watt
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Kilogram, 1},
                    {_siMeasuresList.Metre, 2},
                    {_siMeasuresList.Second, -3}
                };
                var dictionaryEquivalent = new Dictionary<Measure, int> {{Joule, 1}, {_siMeasuresList.Second, -1}};
                return new Measure("Watt", dictionaryEquivalent, dictionarySi);
            }
        }

        public Measure Pascal
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Kilogram, 1},
                    {_siMeasuresList.Metre, -1},
                    {_siMeasuresList.Second, -2}
                };
                var dictionaryEquivalent = new Dictionary<Measure, int> {{Newton, 1}, {_siMeasuresList.Metre, -2}};
                return new Measure("Pascal", dictionaryEquivalent, dictionarySi);
            }
        }

        public Measure Lumen
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Candela, 1},
                    {_siMeasuresList.Metre, 2},
                    {_siMeasuresList.Metre, -2}
                };
                var dictionaryEquivalent = new Dictionary<Measure, int> {{_siMeasuresList.Candela, 1}, {Steradian, 1}};
                return new Measure("Lumen", dictionaryEquivalent, dictionarySi);
            }
        }

        public Measure Lux
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Candela, 1},
                    {_siMeasuresList.Metre, 2},
                    {_siMeasuresList.Metre, -4}
                };
                var dictionaryEquivalent = new Dictionary<Measure, int> {{Lumen, 1}, {_siMeasuresList.Metre, -2}};
                return new Measure("Lux", dictionaryEquivalent, dictionarySi);
            }
        }

        public Measure Coulomb
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Ampere, 1},
                    {_siMeasuresList.Second, 1}
                };
                return new Measure("Coulomb", dictionarySi);
            }
        }

        public Measure Volt
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Kilogram, 1},
                    {_siMeasuresList.Metre, 2},
                    {_siMeasuresList.Second, -3},
                    {_siMeasuresList.Ampere, -1}
                };
                var dictionaryEquivalent = new Dictionary<Measure, int> {{Joule, 1}, {Coulomb, -1}};
                return new Measure("Volt", dictionaryEquivalent, dictionarySi);
            }
        }

        public Measure Ohm
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Kilogram, 1},
                    {_siMeasuresList.Metre, 2},
                    {_siMeasuresList.Second, -3},
                    {_siMeasuresList.Ampere, -2}
                };
                var dictionaryEquivalent = new Dictionary<Measure, int> {{Volt, 1}, {_siMeasuresList.Ampere, -1}};
                return new Measure("Ohm", dictionaryEquivalent, dictionarySi);
            }
        }

        public Measure Farad
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Kilogram, -1},
                    {_siMeasuresList.Metre, -2},
                    {_siMeasuresList.Second, 4},
                    {_siMeasuresList.Ampere, 2}
                };
                var dictionaryEquivalent = new Dictionary<Measure, int> {{Coulomb, 1}, {Volt, -1}};
                return new Measure("Farad", dictionaryEquivalent, dictionarySi);
            }
        }

        public Measure Weber
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Kilogram, 1},
                    {_siMeasuresList.Metre, 2},
                    {_siMeasuresList.Second, -2},
                    {_siMeasuresList.Ampere, -1}
                };

                return new Measure("Weber", dictionarySi);
            }
        }

        public Measure Tesla
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Kilogram, 1},
                    {_siMeasuresList.Second, -2},
                    {_siMeasuresList.Ampere, -1}
                };

                var dictionaryEquivalent = new Dictionary<Measure, int> {{Weber, 1}, {_siMeasuresList.Metre, -2}};
                return new Measure("Tesla", dictionaryEquivalent, dictionarySi);
            }
        }

        public Measure Henry
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Kilogram, 1},
                    {_siMeasuresList.Metre, 2},
                    {_siMeasuresList.Second, -2},
                    {_siMeasuresList.Ampere, -2}
                };

                return new Measure("Henry", dictionarySi);
            }
        }

        public Measure Siemens
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Kilogram, -1},
                    {_siMeasuresList.Metre, -2},
                    {_siMeasuresList.Second, 3},
                    {_siMeasuresList.Ampere, 2}
                };
                var dictionaryEquivalent = new Dictionary<Measure, int> {{Ohm, -1}};
                return new Measure("Siemens", dictionaryEquivalent, dictionarySi);
            }
        }

        public Measure Becquerel
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int> {{_siMeasuresList.Second, -1}};

                return new Measure("Becquerel", dictionarySi);
            }
        }

        public Measure Gray
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Metre, 2},
                    {_siMeasuresList.Second, -2}
                };

                var dictionaryEquivalent = new Dictionary<Measure, int> {{Joule, 1}, {_siMeasuresList.Kilogram, -1}};
                return new Measure("Gray", dictionaryEquivalent, dictionarySi);
            }
        }

        public Measure Sievert
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Metre, 2},
                    {_siMeasuresList.Second, -2}
                };

                var dictionaryEquivalent = new Dictionary<Measure, int> {{Joule, 1}, {_siMeasuresList.Kilogram, -1}};
                return new Measure("Sievert", dictionaryEquivalent, dictionarySi);
            }
        }

        public Measure Katal
        {
            get
            {
                var dictionarySi = new Dictionary<Measure, int>
                {
                    {_siMeasuresList.Mole, 1},
                    {_siMeasuresList.Second, -1}
                };
                return new Measure("Katal", dictionarySi);
            }
        }
    }
}