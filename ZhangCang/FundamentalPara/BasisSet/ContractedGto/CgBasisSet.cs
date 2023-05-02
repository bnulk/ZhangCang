using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhangCang.FundamentalPara.BasisSet.ContractedGto
{
    internal class CgBasisSet
    {
        CgBasisSetStruct[] cgBasisSets= new CgBasisSetStruct[111];

        internal CgBasisSetStruct[] CgBasisSets { get => cgBasisSets; set => cgBasisSets = value; }

        /*
        CgBasisSetStruct H = new CgBasisSetStruct();
        CgBasisSetStruct He = new CgBasisSetStruct();
        CgBasisSetStruct Li = new CgBasisSetStruct();
        CgBasisSetStruct Be = new CgBasisSetStruct();
        CgBasisSetStruct B = new CgBasisSetStruct();
        CgBasisSetStruct C = new CgBasisSetStruct();
        CgBasisSetStruct N = new CgBasisSetStruct();
        CgBasisSetStruct O = new CgBasisSetStruct();
        CgBasisSetStruct F = new CgBasisSetStruct();
        CgBasisSetStruct Ne = new CgBasisSetStruct();
        CgBasisSetStruct Na = new CgBasisSetStruct();
        CgBasisSetStruct Mg = new CgBasisSetStruct();
        CgBasisSetStruct Al = new CgBasisSetStruct();
        CgBasisSetStruct Si = new CgBasisSetStruct();
        CgBasisSetStruct P = new CgBasisSetStruct();
        CgBasisSetStruct S = new CgBasisSetStruct();
        CgBasisSetStruct Cl = new CgBasisSetStruct();
        CgBasisSetStruct Ar = new CgBasisSetStruct();
        CgBasisSetStruct K = new CgBasisSetStruct();
        CgBasisSetStruct Ca = new CgBasisSetStruct();
        CgBasisSetStruct Sc = new CgBasisSetStruct();
        CgBasisSetStruct Ti = new CgBasisSetStruct();
        CgBasisSetStruct V = new CgBasisSetStruct();
        CgBasisSetStruct Cr = new CgBasisSetStruct();
        CgBasisSetStruct Mn = new CgBasisSetStruct();
        CgBasisSetStruct Fe = new CgBasisSetStruct();
        CgBasisSetStruct Co = new CgBasisSetStruct();
        CgBasisSetStruct Ni = new CgBasisSetStruct();
        CgBasisSetStruct Cu = new CgBasisSetStruct();
        CgBasisSetStruct Zn = new CgBasisSetStruct();
        CgBasisSetStruct Ga = new CgBasisSetStruct();
        CgBasisSetStruct Ge = new CgBasisSetStruct();
        CgBasisSetStruct As = new CgBasisSetStruct();
        CgBasisSetStruct Se = new CgBasisSetStruct();
        CgBasisSetStruct Br = new CgBasisSetStruct();
        CgBasisSetStruct Kr = new CgBasisSetStruct();
        CgBasisSetStruct Rb = new CgBasisSetStruct();
        CgBasisSetStruct Cs = new CgBasisSetStruct();
        CgBasisSetStruct Y = new CgBasisSetStruct();
        CgBasisSetStruct Zr = new CgBasisSetStruct();
        CgBasisSetStruct Nb = new CgBasisSetStruct();
        CgBasisSetStruct Mo = new CgBasisSetStruct();
        CgBasisSetStruct Tc = new CgBasisSetStruct();
        CgBasisSetStruct Ru = new CgBasisSetStruct();
        CgBasisSetStruct Rh = new CgBasisSetStruct();
        CgBasisSetStruct Pd = new CgBasisSetStruct();
        CgBasisSetStruct Ag = new CgBasisSetStruct();
        CgBasisSetStruct Cd = new CgBasisSetStruct();
        CgBasisSetStruct In = new CgBasisSetStruct();
        CgBasisSetStruct Sn = new CgBasisSetStruct();
        CgBasisSetStruct Sb = new CgBasisSetStruct();
        CgBasisSetStruct Te = new CgBasisSetStruct();
        CgBasisSetStruct I = new CgBasisSetStruct();

        internal CgBasisSetStruct H1 { get => H; set => H = value; }
        internal CgBasisSetStruct He1 { get => He; set => He = value; }
        internal CgBasisSetStruct Li1 { get => Li; set => Li = value; }
        internal CgBasisSetStruct Be1 { get => Be; set => Be = value; }
        internal CgBasisSetStruct B1 { get => B; set => B = value; }
        internal CgBasisSetStruct C1 { get => C; set => C = value; }
        internal CgBasisSetStruct N1 { get => N; set => N = value; }
        internal CgBasisSetStruct O1 { get => O; set => O = value; }
        internal CgBasisSetStruct F1 { get => F; set => F = value; }
        internal CgBasisSetStruct Ne1 { get => Ne; set => Ne = value; }
        internal CgBasisSetStruct Na1 { get => Na; set => Na = value; }
        internal CgBasisSetStruct Mg1 { get => Mg; set => Mg = value; }
        internal CgBasisSetStruct Al1 { get => Al; set => Al = value; }
        internal CgBasisSetStruct Si1 { get => Si; set => Si = value; }
        internal CgBasisSetStruct P1 { get => P; set => P = value; }
        internal CgBasisSetStruct S1 { get => S; set => S = value; }
        internal CgBasisSetStruct Cl1 { get => Cl; set => Cl = value; }
        internal CgBasisSetStruct Ar1 { get => Ar; set => Ar = value; }
        internal CgBasisSetStruct K1 { get => K; set => K = value; }
        internal CgBasisSetStruct Ca1 { get => Ca; set => Ca = value; }
        internal CgBasisSetStruct Sc1 { get => Sc; set => Sc = value; }
        internal CgBasisSetStruct Ti1 { get => Ti; set => Ti = value; }
        internal CgBasisSetStruct V1 { get => V; set => V = value; }
        internal CgBasisSetStruct Cr1 { get => Cr; set => Cr = value; }
        internal CgBasisSetStruct Mn1 { get => Mn; set => Mn = value; }
        internal CgBasisSetStruct Fe1 { get => Fe; set => Fe = value; }
        internal CgBasisSetStruct Co1 { get => Co; set => Co = value; }
        internal CgBasisSetStruct Ni1 { get => Ni; set => Ni = value; }
        internal CgBasisSetStruct Cu1 { get => Cu; set => Cu = value; }
        internal CgBasisSetStruct Zn1 { get => Zn; set => Zn = value; }
        internal CgBasisSetStruct Ga1 { get => Ga; set => Ga = value; }
        internal CgBasisSetStruct Ge1 { get => Ge; set => Ge = value; }
        internal CgBasisSetStruct As1 { get => As; set => As = value; }
        internal CgBasisSetStruct Se1 { get => Se; set => Se = value; }
        internal CgBasisSetStruct Br1 { get => Br; set => Br = value; }
        internal CgBasisSetStruct Kr1 { get => Kr; set => Kr = value; }
        internal CgBasisSetStruct Rb1 { get => Rb; set => Rb = value; }
        internal CgBasisSetStruct Cs1 { get => Cs; set => Cs = value; }
        internal CgBasisSetStruct Y1 { get => Y; set => Y = value; }
        internal CgBasisSetStruct Zr1 { get => Zr; set => Zr = value; }
        internal CgBasisSetStruct Nb1 { get => Nb; set => Nb = value; }
        internal CgBasisSetStruct Mo1 { get => Mo; set => Mo = value; }
        internal CgBasisSetStruct Tc1 { get => Tc; set => Tc = value; }
        internal CgBasisSetStruct Ru1 { get => Ru; set => Ru = value; }
        internal CgBasisSetStruct Rh1 { get => Rh; set => Rh = value; }
        internal CgBasisSetStruct Pd1 { get => Pd; set => Pd = value; }
        internal CgBasisSetStruct Ag1 { get => Ag; set => Ag = value; }
        internal CgBasisSetStruct Cd1 { get => Cd; set => Cd = value; }
        internal CgBasisSetStruct In1 { get => In; set => In = value; }
        internal CgBasisSetStruct Sn1 { get => Sn; set => Sn = value; }
        internal CgBasisSetStruct Sb1 { get => Sb; set => Sb = value; }
        internal CgBasisSetStruct Te1 { get => Te; set => Te = value; }
        internal CgBasisSetStruct I1 { get => I; set => I = value; }
        */
    }
}
