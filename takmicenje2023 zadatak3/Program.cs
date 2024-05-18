internal class Program
{
    private static void Main(string[] args)
    {
        int xp, yp, xz, yz, razdaljina1 = -1, min, xs = 0, ys = 0, razlikaX, razlikaY, xk = 0, yk = 0, kraj = 0, pomxz, pomyz, pomxp, pomyp, brp = 0, brz = 0;
        int[] razdaljina = new int[4], pasPoljaX = new int[20], pasPoljaY = new int[20], zecPoljaX = new int[20], zecPoljaY = new int[20];
        char[,] mat = new char[20, 20];
        Console.WriteLine("Unesite ulazne podatke");
        xp = int.Parse(Console.ReadLine());
        yp = int.Parse(Console.ReadLine());
        xz = int.Parse(Console.ReadLine());
        yz = int.Parse(Console.ReadLine());
        Console.WriteLine(xp +  " " + yp + " " + xz + " " + yz);

        //3.1
        Console.WriteLine("\n\n************ Odgovor 1 *************\n\n");
        mat = pocetnaBasta();
        iscrtajBastu(mat);

        //3.2
        Console.WriteLine("\n\n************ Odgovor 2 *************\n\n");
        mat = pocetnaBasta();
        for (int i = 0; i < 20; i++)
            for (int j = 0; j < 20; j++) {
                if ((xp == i) && (yp == j)) mat[i, j] = 'P';
                if ((xz == i) && (yz == j)) mat[i, j] = 'Z';
            }
        iscrtajBastu(mat);

        //3.3
        Console.WriteLine("\n\n************ Odgovor 3 *************\n\n");
        mat = pocetnaBasta();
        pomxp = xp;
        pomyp = yp;
        pomxz = xz;
        pomyz = yz;
        //gde je zecu najblize da bezi
        razdaljina[0] = xz;
        razdaljina[1] = yz;
        razdaljina[2] = Math.Abs(xz - 19);
        razdaljina[3] = Math.Abs(yz - 19);
        min = razdaljina[0];
        razdaljina1 = 0;
        for(int i = 1; i < 4; i++)
        {
            if (min > razdaljina[i])
            {
                min = razdaljina[i];
                razdaljina1 = i;
            }
        }
        switch (razdaljina1)
        {
            case 0: xs = -1 ; break;
            case 1: ys = -1 ; break;
            case 2: xs = 1 ; break;
            case 3: ys = 1 ; break;
        }

        while (kraj == 0)
        {
            // pas
            for (int i = 0; i < 3; i++)
            {
                pasPoljaX[brp] = xp;
                pasPoljaY[brp] = yp;
                brp++;
                razlikaX = xp - xz;
                razlikaY = yp - yz;
                if (razlikaX == 0) xk = 0;
                if (razlikaX > 0) xk = -1;
                if (razlikaX < 0) xk = 1;
                if (razlikaY == 0) yk = 0;
                if (razlikaY > 0) yk = -1;
                if (razlikaY < 0) yk = 1;
                xp += xk;
                yp += yk;
                if (yk == 0 && xk == 0) kraj = 1;
            }
            //zec
            zecPoljaX[brz] = xz;
            zecPoljaY[brz] = yz;
            brz++;
            xz += xs;
            yz += ys;
            if (xz < 0 || yz < 0 || xz > 19 || yz > 19) kraj = 2;
        }

        if (kraj == 1) mat[xp, yp] = 'W';
        else mat[xp, yp] = 'L';
        iscrtajBastu(mat);


        //3.4
        Console.WriteLine("\n\n************ Odgovor 4 *************\n\n");
        mat = pocetnaBasta();
        xp = pomxp;
        yp = pomyp;
        xz = pomxz;
        yz = pomyz;
        for (int i = 0; i < brz; i++)
        {
            for (int j = 0; j < brp; j++)
                if (pasPoljaX[j] == zecPoljaX[i] && pasPoljaY[j] == zecPoljaY[i]) mat[pasPoljaX[j], pasPoljaY[j]] = 'Y';
            if (mat[zecPoljaX[i], zecPoljaY[i]] != 'Y')
                mat[zecPoljaX[i], zecPoljaY[i]] = 'O';
        }
        for(int i = 0; i < brp; i++)
            if (mat[pasPoljaX[i], pasPoljaY[i]] != 'Y')
                mat[pasPoljaX[i], pasPoljaY[i]] = 'X';
        iscrtajBastu(mat);
    }

    static void iscrtajBastu(char[,] mat)
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                Console.Write(mat[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static char[,] pocetnaBasta()
    {
        char[,] mat = new char[20, 20];
        for (int i = 0; i < 20; i++)
            for (int j = 0; j < 20; j++)
                mat[i, j] = '-';
        return mat;
    }
}