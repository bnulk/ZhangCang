using System;
using System.Text.RegularExpressions;
using ZhangCang.Data;
using ZhangCang.FundamentalConstants;

namespace ZhangCang.Input.GaussianInput
{
    internal class ReadCartesianCoordinates
    {
        private GaussianInputPackage _gaussianInputPackage;
        private int[] atomicNumbers_;
        private double[,] cartesian3_;

        public ReadCartesianCoordinates(GaussianInputPackage gaussianInputPackage)
        {
            this._gaussianInputPackage = gaussianInputPackage;

            if (this._gaussianInputPackage.molecularCartesian.Count == 0)
            {
                atomicNumbers_= new int[0];
                cartesian3_ = new double[0, 0];
            }
            else
            {
                atomicNumbers_ = new int[this._gaussianInputPackage.molecularCartesian.Count];
                cartesian3_ = new double[this._gaussianInputPackage.molecularCartesian.Count, 3];
            }

        }

        public double[,] Cartesian3_ { get => cartesian3_; set => cartesian3_ = value; }
        public int[] AtomicNumbers_ { get => atomicNumbers_; set => atomicNumbers_ = value; }

        public void Run()
        {
            int numberOfAtoms = _gaussianInputPackage.N;
            Atoms atoms = new Atoms();
            int i, j;

            if (this._gaussianInputPackage.molecularCartesian.Count != 0)
            {
                for (i = 0; i < numberOfAtoms; i++)
                {
                    atomicNumbers_[i] = atoms.SymbolToNumber(_gaussianInputPackage.molecularCartesian[i]);
                    for (j = 0; j < 3; j++)
                    {
                        cartesian3_[i, j] = _gaussianInputPackage.molecularVariable[3 * i + j];
                    }
                }
            }
                
        }




    }
}
