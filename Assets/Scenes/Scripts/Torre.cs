using System;
using it.unical.mat.embasp.languages;

namespace progettoIA
{
    public class Torre
    {
        int attiva; // 0 = non attiva 
        string piattaforma;
        int livello;
        int tipoTorretta;
        int costo;

        public Torre(int attiva, string piattaforma, int livello, int tipoTorretta)
        {
            this.attiva = attiva;
            this.piattaforma = piattaforma;
            this.livello = livello;
            this.tipoTorretta = tipoTorretta;
            this.costo = tipoTorretta == 1 ? 10 : 14;
        }

        //public override string ToString()
        //{
        //    return ( attiva == 0
        //            ? "Torre [" + this.piattaforma + "] non attiva."
        //            : "Torre [" + this.piattaforma + "] attiva livello " + this.livello;);
        //}

    }

    [Id("prova")]
    public class Prova
    {
        [Param(0)]
        string first;
        [Param(1)]
        string second;

        public Prova(string first, string second)
        {
            this.first = first;
            this.second = second;
        }

        //public override string ToString()
        //{
        //    return ( attiva == 0
        //            ? "Torre [" + this.piattaforma + "] non attiva."
        //            : "Torre [" + this.piattaforma + "] attiva livello " + this.livello;);
        //}

    }

    [Id("res")]
    public class Res
    {
        [Param(0)]
        string arg;

        public Res(string arg)
        {
            this.arg = arg;
        }
    }
}