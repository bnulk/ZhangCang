﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhangCang.Data;
using ZhangCang.FundamentalConstants;

namespace ZhangCang.Input
{
    internal class InputData2Element_App
    {
        private InputData _inputData;
        private Control _control;
        private Element element_;

        public Element Element_ { get => element_; set => element_ = value; }

        public InputData2Element_App(InputData inputData, Control control)
        {
            this._inputData = inputData;
            this._control = control;
            element_= new Element();
        }

        public void Run()
        {
            element_.control = _control;
            element_.keyword = _inputData.keyword;
            element_.molecule = _inputData.molecule;
            MoleculeCoordinate_Angstroms2Bohr(ref element_.molecule.cartesian3);
            element_.zMatrix = _inputData.zMatrix;
        }


        /// <summary>
        /// 把分子坐标的单位从埃米转到玻尔
        /// </summary>
        /// <param name="cartesian3">分子坐标</param>
        private void MoleculeCoordinate_Angstroms2Bohr(ref double[,] cartesian3)
        {
            int row, col;
            row = cartesian3.GetLength(0);
            col = cartesian3.GetLength(1);

            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    cartesian3[i, j] = cartesian3[i, j] / PhysConst.bohr2angstroms;
                }
            }
        }
    }
}
