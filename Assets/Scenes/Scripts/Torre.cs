using System;
using it.unical.mat.embasp.languages;

namespace progettoIA
{
    [Id("torre")]
    public class Torre
    {
        [Param(0)]
        int attiva; // 0 = non attiva 
        
        [Param(1)]
        int piattaforma;
        
        [Param(2)]
        int livello;
        
        [Param(3)]
        int tipoTorretta; // 1 o 2

        [Param(4)]
        int costoTorretta;

        [Param(5)]
        int costoAumentoLivello;

        public Torre()
        {
            this.attiva = 0;
            this.piattaforma = 0;
            this.livello = 0;
            this.tipoTorretta = 0;
            this.costoTorretta = 0;
            this.costoAumentoLivello = 0;
        }

        public Torre(int attiva, int piattaforma, int livello, int tipoTorretta, int costoTorretta, int costoAumentoLivello)
        {
            this.attiva = attiva;
            this.piattaforma = piattaforma;
            this.livello = livello;
            this.tipoTorretta = tipoTorretta;
            this.costoTorretta = costoTorretta;
            this.costoAumentoLivello = costoAumentoLivello;
        }

        public int getAttiva()
        {
            return this.attiva;
        }

        public void setAttiva(int attiva)
        {
            this.attiva = attiva;
        }

        public int getPiattaforma()
        {
            return this.piattaforma;
        }

        public void setPiattaforma(int piattaforma)
        {
            this.piattaforma = piattaforma;
        }

        public int getLivello()
        {
            return this.livello;
        }

        public void setLivello(int livello)
        {
            this.livello = livello;
        }

        public int getTipoTorretta()
        {
            return this.tipoTorretta;
        }

        public void setTipoTorretta(int tipoTorretta)
        {
            this.tipoTorretta = tipoTorretta;
        }

        public int getCostoTorretta()
        {
            return this.costoTorretta;
        }

        public void setCostoTorretta(int costoTorretta)
        {
            this.costoTorretta = costoTorretta;
        }

        public int getCostoAumentoLivello()
        {
            return this.costoAumentoLivello;
        }

        public void setCostoAumentoLivello(int costoAumentoLivello)
        {
            this.costoAumentoLivello = costoAumentoLivello;
        }

        public string toString()
        {
            return ( attiva == 0
                    ? "Torre [" + this.piattaforma + "] non attiva."
                    : "Torre [" + this.piattaforma + "] attiva livello " + this.livello);
        }

    }

    [Id("monete")]
    public class Monete
    {
        [Param(0)]
        int numeroMonete;

        public Monete(int numeroMonete)
        {
            this.numeroMonete = numeroMonete;
        }

        public int getNumeroMonete()
        {
            return this.numeroMonete;
        }

        public void set(int numeroMonete)
        {
            this.numeroMonete = numeroMonete;
        }

    }

    [Id("attiva")]
    public class Attiva
    {
        [Param(0)]
        int stato;

        public Attiva(int stato)
        {
            this.stato = stato;
        }

        public int getStato()
        {
            return this.stato;
        }

        public void set(int stato)
        {
            this.stato = stato;
        }
    }

    [Id("prova")]
    public class Prova
    {
        [Param(0)]
        int first;
        [Param(1)]
        int second;

        public Prova()
        {
            this.first = 0;
            this.second = 0;
        }

        public Prova(int first, int second)
        {
            this.first = first;
            this.second = second;
        }

        public int getFirst()
        {
            return this.first;
        }

        public void setFirst(int first)
        {
            this.first = first;
        }

        public int getSecond()
        {
            return this.second;
        }

        public void setSecond(int second)
        {
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
        int arg;

        public Res()
        {
            this.arg = 0;
        }

        public Res(int arg)
        {
            this.arg = arg;
        }

        public int getArg()
        {
            return this.arg;
        }

        public void setArg(int arg)
        {
            this.arg = arg;
        }

        public string toString()
        {
            return "res(" + this.arg + "). ";
        }
    }

    [Id("notres")]
    public class NotRes
    {
        [Param(0)]                              
        int arg;

        public NotRes()
        {
            this.arg = 0;
        }

        public NotRes(int arg)
        {
            this.arg = arg;
        }

        public int getArg()
        {
            return this.arg;
        }

        public void setArg(int arg)
        {
            this.arg = arg;
        }

        public string toString()
        {
            return "notres(" + this.arg + "). ";
        }
    }
}