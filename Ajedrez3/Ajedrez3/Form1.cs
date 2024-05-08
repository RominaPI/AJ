using Ajedrez3.Properties;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Ajedrez3
{

    public partial class Form1 : Form
    {
        private PictureBox[,] tablero;

        public Form1()
        {
            InitializeComponent();
            InicializarTablero();
        }

        private void InicializarTablero()
        {

            // Inicializar la matriz con el tamaño del TableLayoutPanel
            tablero = new PictureBox[tableLayoutPanel1.RowCount, tableLayoutPanel1.ColumnCount];

            // Recorrer cada celda del TableLayoutPanel
            for (int fila = 0; fila < tableLayoutPanel1.RowCount; fila++)
            {
                for (int columna = 0; columna < tableLayoutPanel1.ColumnCount; columna++)
                {
                    // Obtener el control en la posición actual del TableLayoutPanel
                    Control Posicion = tableLayoutPanel1.GetControlFromPosition(columna, fila);

                    // Verificar si el control es un PictureBox y agregarlo a la matriz
                    if (Posicion is PictureBox pictureBox)
                    {
                        tablero[fila, columna] = pictureBox;
                    }
                }
            }

            tablero[0, 0] = TorreN1;
            tablero[0, 1] = CaballoN1;
            tablero[0, 2] = AlfilN1;
            tablero[0, 3] = ReinaN;
            tablero[0, 4] = ReyN;
            tablero[0, 5] = AlfilN2;
            tablero[0, 6] = CaballoN2;
            tablero[0, 7] = TorreN2;

            tablero[1, 0] = PeonN1;
            tablero[1, 1] = PeonN2;
            tablero[1, 2] = PeonN3;
            tablero[1, 3] = PeonN4;
            tablero[1, 4] = PeonN5;
            tablero[1, 5] = PeonN6;
            tablero[1, 6] = PeonN7;
            tablero[1, 7] = PeonN8;

            tablero[2, 0] = pictureBox33;
            tablero[2, 1] = pictureBox34;
            tablero[2, 2] = pictureBox35;
            tablero[2, 3] = pictureBox36;
            tablero[2, 4] = pictureBox37;
            tablero[2, 5] = pictureBox38;
            tablero[2, 6] = pictureBox39;
            tablero[2, 7] = pictureBox40;

            tablero[3, 0] = pictureBox41;
            tablero[3, 1] = pictureBox42;
            tablero[3, 2] = pictureBox43;
            tablero[3, 3] = pictureBox44;
            tablero[3, 4] = pictureBox45;
            tablero[3, 5] = pictureBox46;
            tablero[3, 6] = pictureBox47;
            tablero[3, 7] = pictureBox48;

            tablero[4, 0] = pictureBox49;
            tablero[4, 1] = pictureBox50;
            tablero[4, 2] = pictureBox51;
            tablero[4, 3] = pictureBox52;
            tablero[4, 4] = pictureBox53;
            tablero[4, 5] = pictureBox54;
            tablero[4, 6] = pictureBox55;
            tablero[4, 7] = pictureBox56;

            tablero[5, 0] = pictureBox57;
            tablero[5, 1] = pictureBox58;
            tablero[5, 2] = pictureBox59;
            tablero[5, 3] = pictureBox60;
            tablero[5, 4] = pictureBox61;
            tablero[5, 5] = pictureBox62;
            tablero[5, 6] = pictureBox63;
            tablero[5, 7] = pictureBox64;

            tablero[6, 0] = PeonB1;
            tablero[6, 1] = PeonB2;
            tablero[6, 2] = PeonB3;
            tablero[6, 3] = PeonB4;
            tablero[6, 4] = PeonB5;
            tablero[6, 5] = PeonB6;
            tablero[6, 6] = PeonB7;
            tablero[6, 7] = PeonB8;

            tablero[7, 0] = TorreB1;
            tablero[7, 1] = CaballoB1;
            tablero[7, 2] = AlfilB1;
            tablero[7, 3] = ReyB;
            tablero[7, 4] = ReinaB;
            tablero[7, 5] = AlfilB2;
            tablero[7, 6] = CaballoB2;
            tablero[7, 7] = TorreB2;
        }
        private void RealizarMovimiento(int filaDesde, int columnaDesde, int filaHacia, int columnaHacia, PictureBox pieza_a_mover, PictureBox pieza_destino)
        {
            // Mover la imagen de la pieza desde la casilla de origen a la casilla de destino
            PictureBox picture = new PictureBox();
            PictureBox picture2 = new PictureBox();

            picture = pieza_a_mover;
            picture2 = pieza_destino;

            tablero[filaHacia, columnaHacia] = picture;
            tablero[filaHacia, columnaHacia].Location = picture2.Location;
            tablero[filaDesde, columnaDesde] = pieza_destino;
            tablero[filaDesde, columnaDesde].Location = picture.Location;
        }

        protected bool RangoPermitido(int filaDesde, int columnaDesde, int filaHacia, int columnaHacia)
        {
            // Verificar si las coordenadas de inicio y fin están dentro del rango de la matriz o del panel
            if (filaDesde < 0 || filaDesde >= tablero.GetLength(0) ||
                columnaDesde < 0 || columnaDesde >= tablero.GetLength(1) ||
                filaHacia < 0 || filaHacia >= tablero.GetLength(0) ||
                columnaHacia < 0 || columnaHacia >= tablero.GetLength(1))
            {
                return false; // Si alguna coordenada está fuera de rango, el movimiento no es válido
            }

            return true; // Si todas las coordenadas están dentro del rango, el movimiento es válido
        }



        private void PeonN1_Click(object sender, EventArgs e)
        {

            // Obtener la posición actual del PeonN1 en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(PeonN1).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(PeonN1).Column;

            // Calcular la fila hacia la que se quiere mover (en este caso, puede ser una o dos filas más abajo)
            int filaHacia = filaDesde + 1; // Mover una casilla por defecto
            if (MessageBox.Show("¿Quieres mover el peón una o dos casillas?", "Selecciona el movimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaHacia = filaDesde + 2; // Mover dos casillas si el usuario lo decide
            }

            int columnaHacia = columnaDesde;

            // Verificar si el movimiento está dentro del rango permitido
            if (RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
            {
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, PeonN1, tablero[filaHacia, columnaHacia]);

                return;
            }

        }
        private void PeonN2_Click(object sender, EventArgs e)
        {

            // Obtener la posición actual del PeonN1 en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(PeonN2).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(PeonN2).Column;

            // Calcular la fila hacia la que se quiere mover (en este caso, puede ser una o dos filas más abajo)
            int filaHacia = filaDesde + 1; // Mover una casilla por defecto
            if (MessageBox.Show("¿Quieres mover el peón una o dos casillas?", "Selecciona el movimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaHacia = filaDesde + 2; // Mover dos casillas si el usuario lo decide
            }

            int columnaHacia = columnaDesde;

            // Verificar si el movimiento está dentro del rango permitido
            if (RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
            {
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia,  PeonN2, tablero[filaHacia, columnaHacia]);

                return;
            }

        }
        private void PeonN3_Click(object sender, EventArgs e)
        {

            // Obtener la posición actual del PeonN1 en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(PeonN3).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(PeonN3).Column;

            // Calcular la fila hacia la que se quiere mover (en este caso, puede ser una o dos filas más abajo)
            int filaHacia = filaDesde + 1; // Mover una casilla por defecto
            if (MessageBox.Show("¿Quieres mover el peón una o dos casillas?", "Selecciona el movimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaHacia = filaDesde + 2; // Mover dos casillas si el usuario lo decide
            }

            int columnaHacia = columnaDesde;

            // Verificar si el movimiento está dentro del rango permitido
            if (RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
            {
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, PeonN3, tablero[filaHacia, columnaHacia]);

                return;
            }

        }
        private void PeonN4_Click(object sender, EventArgs e)
        {

            // Obtener la posición actual del PeonN1 en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(PeonN4).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(PeonN4).Column;

            // Calcular la fila hacia la que se quiere mover (en este caso, puede ser una o dos filas más abajo)
            int filaHacia = filaDesde + 1;
            if (MessageBox.Show("¿Quieres mover el peón una o dos casillas?", "Selecciona el movimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaHacia = filaDesde + 2;
            }

            int columnaHacia = columnaDesde;

            if (RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
            {
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, PeonN4, tablero[filaHacia, columnaHacia]);

                return;
            }

        }
        private void PeonN5_Click(object sender, EventArgs e)
        {

            int filaDesde = tableLayoutPanel1.GetPositionFromControl(PeonN5).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(PeonN5).Column;

            int filaHacia = filaDesde + 1;
            if (MessageBox.Show("¿Quieres mover el peón una o dos casillas?", "Selecciona el movimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaHacia = filaDesde + 2;
            }

            int columnaHacia = columnaDesde;

            if (RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
            {
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, PeonN5, tablero[filaHacia, columnaHacia]);

                return;
            }

        }
        private void PeonN6_Click(object sender, EventArgs e)
        {
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(PeonN6).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(PeonN6).Column;

            int filaHacia = filaDesde + 1;
            if (MessageBox.Show("¿Quieres mover el peón una o dos casillas?", "Selecciona el movimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaHacia = filaDesde + 2;
            }

            int columnaHacia = columnaDesde;

            if (RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
            {
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, PeonN6, tablero[filaHacia, columnaHacia]);

                return;
            }

        }
        private void PeonN7_Click(object sender, EventArgs e)
        {
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(PeonN7).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(PeonN7).Column;

            int filaHacia = filaDesde + 1;
            if (MessageBox.Show("¿Quieres mover el peón una o dos casillas?", "Selecciona el movimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaHacia = filaDesde + 2;

                int columnaHacia = columnaDesde;

                if (RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
                {
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, PeonN7, tablero[filaHacia, columnaHacia]);

                    return;
                }

            }
        }
        public void PeonN8_Click(object sender, EventArgs e)
        {
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(PeonN8).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(PeonN8).Column;

            int filaHacia = filaDesde + 1;
            if (MessageBox.Show("¿Quieres mover el peón una o dos casillas?", "Selecciona el movimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaHacia = filaDesde + 2;

                int columnaHacia = columnaDesde;

                if (RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
                {
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, PeonN8, tablero[filaHacia, columnaHacia]);

                    return;
                }

            }
        }



        private void PeonB1_Click(object sender, EventArgs e)
        {
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(PeonB1).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(PeonB1).Column;

            int filaHacia = filaDesde - 1;
            if (MessageBox.Show("¿Quieres mover el peón una o dos casillas?", "Selecciona el movimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaHacia = filaDesde - 2;
            }
            int columnaHacia = columnaDesde;

            if (RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
            {
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, PeonB1, tablero[filaHacia, columnaHacia]);

                return;
            }
        }


        private void PeonB2_Click(object sender, EventArgs e)
        {

            // Obtener la posición actual del PeonN1 en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(PeonB2).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(PeonB2).Column;

            // Calcular la fila hacia la que se quiere mover (en este caso, puede ser una o dos filas más abajo)
            int filaHacia = filaDesde - 1; // Mover una casilla por defecto
            if (MessageBox.Show("¿Quieres mover el peón una o dos casillas?", "Selecciona el movimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaHacia = filaDesde - 2; // Mover dos casillas si el usuario lo decide
            }

            int columnaHacia = columnaDesde;

            // Verificar si el movimiento está dentro del rango permitido
            if (RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
            {
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, PeonB1, tablero[filaHacia, columnaHacia]);


                return;
            }

        }
        private void PeonB3_Click(object sender, EventArgs e)
        {

            // Obtener la posición actual del PeonN1 en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(PeonB3).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(PeonB3).Column;

            // Calcular la fila hacia la que se quiere mover (en este caso, puede ser una o dos filas más abajo)
            int filaHacia = filaDesde - 1; // Mover una casilla por defecto
            if (MessageBox.Show("¿Quieres mover el peón una o dos casillas?", "Selecciona el movimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaHacia = filaDesde - 2; // Mover dos casillas si el usuario lo decide
            }

            int columnaHacia = columnaDesde;

            // Verificar si el movimiento está dentro del rango permitido
            if (RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
            {
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, PeonB3, tablero[filaHacia, columnaHacia]);


                return;
            }

        }
        private void PeonB4_Click(object sender, EventArgs e)
        {

            // Obtener la posición actual del PeonN1 en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(PeonB4).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(PeonB4).Column;

            // Calcular la fila hacia la que se quiere mover (en este caso, puede ser una o dos filas más abajo)
            int filaHacia = filaDesde - 1;
            if (MessageBox.Show("¿Quieres mover el peón una o dos casillas?", "Selecciona el movimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaHacia = filaDesde - 2;
            }

            int columnaHacia = columnaDesde;

            if (RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
            {
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, PeonB4, tablero[filaHacia, columnaHacia]);


                return;
            }

        }
        private void PeonB5_Click(object sender, EventArgs e)
        {

            int filaDesde = tableLayoutPanel1.GetPositionFromControl(PeonB5).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(PeonB5).Column;

            int filaHacia = filaDesde - 1;
            if (MessageBox.Show("¿Quieres mover el peón una o dos casillas?", "Selecciona el movimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaHacia = filaDesde - 2;
            }

            int columnaHacia = columnaDesde;

            if (RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
            {
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, PeonB5, tablero[filaHacia, columnaHacia]);


                return;
            }

        }
        private void PeonB6_Click(object sender, EventArgs e)
        {
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(PeonB6).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(PeonB6).Column;

            int filaHacia = filaDesde - 1;
            if (MessageBox.Show("¿Quieres mover el peón una o dos casillas?", "Selecciona el movimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaHacia = filaDesde - 2;
            }

            int columnaHacia = columnaDesde;

            if (RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
            {
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, PeonB6, tablero[filaHacia, columnaHacia]);


                return;
            }

        }
        private void PeonB7_Click(object sender, EventArgs e)
        {
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(PeonB7).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(PeonB7).Column;

            int filaHacia = filaDesde - 1;
            if (MessageBox.Show("¿Quieres mover el peón una o dos casillas?", "Selecciona el movimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaHacia = filaDesde - 2;

                int columnaHacia = columnaDesde;

                if (RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
                {
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, PeonB7, tablero[filaHacia, columnaHacia]);


                    return;
                }

            }
        }
        public void PeonB8_Click(object sender, EventArgs e)
        {
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(PeonB8).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(PeonB8).Column;

            int filaHacia = filaDesde - 1;
            if (MessageBox.Show("¿Quieres mover el peón una o dos casillas?", "Selecciona el movimiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaHacia = filaDesde - 2;

                int columnaHacia = columnaDesde;

                if (RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
                {
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, PeonB8, tablero[filaHacia, columnaHacia]);


                    return;
                }

            }

        }

        private void TorreN1_Click(object sender, EventArgs e)
        {
            // Obtener la posición actual de la torre en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(TorreN1).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(TorreN1).Column;

            // Seleccionar dirección de movimiento
            DialogResult resultado = MessageBox.Show("¿Quieres mover la torre vertical o horizontal?", "Selecciona el movimiento", MessageBoxButtons.YesNoCancel);

            int filaHacia = filaDesde;
            int columnaHacia = columnaDesde;

            if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover verticalmente
            {
                filaHacia = filaDesde + 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, TorreN1, tablero[filaHacia, columnaHacia]);

                return;
            }
            else if (resultado == DialogResult.No && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))// Mover horizontalmente
            {
                // Determinar la dirección (izquierda o derecha)
                resultado = MessageBox.Show("¿Quieres mover la torre hacia la izquierda o hacia la derecha?", "Selecciona la dirección", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes) // Mover hacia la izquierda
                {
                    columnaHacia = columnaDesde - 1;
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, TorreN1, tablero[filaHacia, columnaHacia]);
                    return;
                }
                else // Mover hacia la derecha
                {
                    columnaHacia = columnaDesde + 1;
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, TorreN1, tablero[filaHacia, columnaHacia]);
                    return;
                }
            }
            else // Cancelar movimiento
            {
                return;
            }
        }


        private void TorreN2_Click(object sender, EventArgs e)
        {
            // Obtener la posición actual de la torre en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(TorreN2).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(TorreN2).Column;

            // Seleccionar dirección de movimiento
            DialogResult resultado = MessageBox.Show("¿Quieres mover la torre vertical o horizontal?", "Selecciona el movimiento", MessageBoxButtons.YesNoCancel);

            int filaHacia = filaDesde;
            int columnaHacia = columnaDesde;

            if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover verticalmente
            {
                filaHacia = filaDesde + 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, TorreN2, tablero[filaHacia, columnaHacia]);
                return;
            }
            else if (resultado == DialogResult.No && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))// Mover horizontalmente
            {
                // Determinar la dirección (izquierda o derecha)
                resultado = MessageBox.Show("¿Quieres mover la torre hacia la izquierda o hacia la derecha?", "Selecciona la dirección", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes) // Mover hacia la izquierda
                {
                    columnaHacia = columnaDesde - 1;
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, TorreN2, tablero[filaHacia, columnaHacia]);
                    return;
                }
                else // Mover hacia la derecha
                {
                    columnaHacia = columnaDesde + 1;
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, TorreN2, tablero[filaHacia, columnaHacia]);
                    return;
                }
            }
            else // Cancelar movimiento
            {
                return;
            }
        }




        private void TorreB1_Click(object sender, EventArgs e)
        {
            // Obtener la posición actual de la torre en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(TorreB1).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(TorreB1).Column;

            // Seleccionar dirección de movimiento
            DialogResult resultado = MessageBox.Show("¿Quieres mover la torre vertical o horizontal?", "Selecciona el movimiento", MessageBoxButtons.YesNoCancel);

            int filaHacia = filaDesde;
            int columnaHacia = columnaDesde;

            if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover verticalmente
            {
                filaHacia = filaDesde - 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, TorreB1, tablero[filaHacia, columnaHacia]);
                return;
            }
            else if (resultado == DialogResult.No && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))// Mover horizontalmente
            {
                // Determinar la dirección (izquierda o derecha)
                resultado = MessageBox.Show("¿Quieres mover la torre hacia la izquierda o hacia la derecha?", "Selecciona la dirección", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes) // Mover hacia la izquierda
                {
                    columnaHacia = columnaDesde - 1;
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, TorreB1, tablero[filaHacia, columnaHacia]);
                    return;
                }
                else // Mover hacia la derecha
                {
                    columnaHacia = columnaDesde + 1;
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, TorreB1, tablero[filaHacia, columnaHacia]);
                    return;
                }
            }
            else // Cancelar movimiento
            {
                return;
            }
        }


        private void TorreB2_Click(object sender, EventArgs e)
        {
            // Obtener la posición actual de la torre en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(TorreB2).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(TorreB2).Column;

            // Seleccionar dirección de movimiento
            DialogResult resultado = MessageBox.Show("¿Quieres mover la torre vertical o horizontal?", "Selecciona el movimiento", MessageBoxButtons.YesNoCancel);

            int filaHacia = filaDesde;
            int columnaHacia = columnaDesde;

            if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover verticalmente
            {
                filaHacia = filaDesde - 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, TorreB2, tablero[filaHacia, columnaHacia]);
                return;
            }
            else if (resultado == DialogResult.No && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))// Mover horizontalmente
            {
                // Determinar la dirección (izquierda o derecha)
                resultado = MessageBox.Show("¿Quieres mover la torre hacia la izquierda o hacia la derecha?", "Selecciona la dirección", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes) // Mover hacia la izquierda
                {
                    columnaHacia = columnaDesde - 1;
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, TorreB2, tablero[filaHacia, columnaHacia]);
                    return;
                }
                else // Mover hacia la derecha
                {
                    columnaHacia = columnaDesde + 1;
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, TorreB2, tablero[filaHacia, columnaHacia]);
                    return;
                }
            }
            else // Cancelar movimiento
            {
                return;
            }
        }
        private void AlfilN1_Click(object sender, EventArgs e)
        {
            // Obtener la posición actual del alfil en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(AlfilN1).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(AlfilN1).Column;

            // Pedir al jugador que seleccione la dirección de movimiento
            DialogResult resultado = MessageBox.Show("¿Quieres mover el alfil en diagonal abajo-izquierda o abajo-derecha?", "Selecciona la dirección", MessageBoxButtons.YesNoCancel);

            int filaHacia = filaDesde;
            int columnaHacia = columnaDesde;

            if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover en diagonal hacia arriba-izquierda
            {
                filaHacia = filaDesde + 1;
                columnaHacia = columnaDesde - 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, AlfilN1, tablero[filaHacia, columnaHacia]);
                return;
            }
            else if (resultado == DialogResult.No && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover en diagonal hacia arriba-derecha
            {
                filaHacia = filaDesde + 1;
                columnaHacia = columnaDesde + 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, AlfilN1, tablero[filaHacia, columnaHacia]);
                return;

            }
            else if (resultado == DialogResult.Cancel)
            {
                MessageBox.Show("Cancelado");
            }
        }

        private void AlfilN2_Click(object sender, EventArgs e)
        {
            // Obtener la posición actual del alfil en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(AlfilN2).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(AlfilN2).Column;

            // Pedir al jugador que seleccione la dirección de movimiento
            DialogResult resultado = MessageBox.Show("¿Quieres mover el alfil en diagonal abajo-izquierda o abajo-derecha?", "Selecciona la dirección", MessageBoxButtons.YesNoCancel);

            int filaHacia = filaDesde;
            int columnaHacia = columnaDesde;

            if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover en diagonal hacia arriba-izquierda
            {
                filaHacia = filaDesde + 1;
                columnaHacia = columnaDesde - 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, AlfilN2, tablero[filaHacia, columnaHacia]);
                return;
            }
            else if (resultado == DialogResult.No && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover en diagonal hacia arriba-derecha
            {
                filaHacia = filaDesde + 1;
                columnaHacia = columnaDesde + 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, AlfilN2, tablero[filaHacia, columnaHacia]);
                return;

            }
            else if (resultado == DialogResult.Cancel)
            {
                MessageBox.Show("Cancelado");
            }



        }
        private void AlfilB1_Click(object sender, EventArgs e)
        {
            // Obtener la posición actual del alfil en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(AlfilB1).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(AlfilB1).Column;

            // Pedir al jugador que seleccione la dirección de movimiento
            DialogResult resultado = MessageBox.Show("¿Quieres mover el alfil en diagonal hacia arriba-izquierda, arriba-derecha?", "Selecciona la dirección", MessageBoxButtons.YesNoCancel);

            int filaHacia = filaDesde;
            int columnaHacia = columnaDesde;


            if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover en diagonal hacia arriba-izquierda
            {
                filaHacia = filaDesde - 1;
                columnaHacia = columnaDesde - 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, AlfilB1, tablero[filaHacia, columnaHacia]);
                return;
            }
            else if (resultado == DialogResult.No && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover en diagonal hacia arriba-derecha
            {
                filaHacia = filaDesde - 1;
                columnaHacia = columnaDesde + 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, AlfilB1, tablero[filaHacia, columnaHacia]);
                return;
            }
            else if (resultado == DialogResult.Cancel) // Mover en diagonal hacia abajo-izquierda
            {
                filaHacia = filaDesde + 1;
                columnaHacia = columnaDesde - 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, AlfilB1, tablero[filaHacia, columnaHacia]);
                return;
            }
        }

        private void AlfilB2_Click(object sender, EventArgs e)
        {
            // Obtener la posición actual del alfil en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(AlfilB2).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(AlfilB2).Column;

            // Pedir al jugador que seleccione la dirección de movimiento
            DialogResult resultado = MessageBox.Show("¿Quieres mover el alfil en diagonal hacia arriba-izquierda, arriba-derecha?", "Selecciona la dirección", MessageBoxButtons.YesNoCancel);

            int filaHacia = filaDesde;
            int columnaHacia = columnaDesde;


            if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover en diagonal hacia arriba-izquierda
            {
                filaHacia = filaDesde - 1;
                columnaHacia = columnaDesde - 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, AlfilB2, tablero[filaHacia, columnaHacia]);
                return;
            }
            else if (resultado == DialogResult.No && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover en diagonal hacia arriba-derecha
            {
                filaHacia = filaDesde - 1;
                columnaHacia = columnaDesde + 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, AlfilB2, tablero[filaHacia, columnaHacia]);
                return;
                return;
            }
            else if (resultado == DialogResult.Cancel) // Mover en diagonal hacia abajo-izquierda
            {
                filaHacia = filaDesde + 1;
                columnaHacia = columnaDesde - 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, AlfilB2, tablero[filaHacia, columnaHacia]);
                return;
                return;
            }
        }

        private void ReinaN_Click(object sender, EventArgs e)
        {
            // Obtener la posición actual de la reina en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(ReinaN).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(ReinaN).Column;

            // Pedir al jugador que seleccione la dirección de movimiento
            DialogResult resultado = MessageBox.Show("¿Quieres mover la reina horizontalmente, verticalmente o en diagonal?", "Selecciona el movimiento", MessageBoxButtons.YesNoCancel);

            int filaHacia = filaDesde;
            int columnaHacia = columnaDesde;

            if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover horizontalmente 
            {
                // Determinar la dirección (izquierda o derecha)
                resultado = MessageBox.Show("¿Quieres mover la reina hacia la izquierda o hacia la derecha?", "Selecciona la dirección", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))// Mover hacia la izquierda
                {
                    columnaHacia = columnaDesde - 1;
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, ReinaN, tablero[filaHacia, columnaHacia]);
                    return;
                }
                else // Mover hacia la derecha
                {
                    columnaHacia = columnaDesde + 1;
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, ReinaN, tablero[filaHacia, columnaHacia]);
                    return;
                }
            }
            else if (resultado == DialogResult.No) // Mover verticalmente 
            {
                filaHacia = filaDesde + 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, ReinaN, tablero[filaHacia, columnaHacia]);
                return;
            }
            else // Mover en diagonal (como el alfil)
            {
                // Pedir al jugador que seleccione la dirección de movimiento diagonal
                resultado = MessageBox.Show("¿Quieres mover la reina en diagonal hacia abajo-izquierda o abajo-derecha?", "Selecciona la dirección", MessageBoxButtons.YesNoCancel);

                if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover en diagonal hacia arriba-izquierda
                {
                    filaHacia = filaDesde + 1;
                    columnaHacia = columnaDesde - 1;
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, ReinaN, tablero[filaHacia, columnaHacia]);
                    return;
                }
                else if (resultado == DialogResult.No && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover en diagonal hacia arriba-derecha
                {
                    filaHacia = filaDesde + 1;
                    columnaHacia = columnaDesde + 1;
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, ReinaN, tablero[filaHacia, columnaHacia]);
                    return;
                }
            }
        }



        private void ReinaB_Click(object sender, EventArgs e)
        {
            // Obtener la posición actual de la reina en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(ReinaB).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(ReinaB).Column;

            // Pedir al jugador que seleccione la dirección de movimiento
            DialogResult resultado = MessageBox.Show("¿Quieres mover la reina horizontalmente, verticalmente o en diagonal?", "Selecciona el movimiento", MessageBoxButtons.YesNoCancel);

            int filaHacia = filaDesde;
            int columnaHacia = columnaDesde;

            if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover horizontalmente 
            {
                // Determinar la dirección (izquierda o derecha)
                resultado = MessageBox.Show("¿Quieres mover la reina hacia la izquierda o hacia la derecha?", "Selecciona la dirección", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))// Mover hacia la izquierda
                {
                    columnaHacia = columnaDesde - 1;
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, ReinaB, tablero[filaHacia, columnaHacia]);
                    return;
                }
                else // Mover hacia la derecha
                {
                    columnaHacia = columnaDesde + 1;
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, ReinaB, tablero[filaHacia, columnaHacia]);
                    return;
                }
            }
            else if (resultado == DialogResult.No) // Mover verticalmente 
            {
                filaHacia = filaDesde - 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, ReinaB, tablero[filaHacia, columnaHacia]);
                return;
            }
            else // Mover en diagonal (como el alfil)
            {
                // Pedir al jugador que seleccione la dirección de movimiento diagonal
                resultado = MessageBox.Show("¿Quieres mover la reina en diagonal hacia arriba-izquierda o arriba-derecha?", "Selecciona la dirección", MessageBoxButtons.YesNoCancel);

                if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover en diagonal hacia arriba-izquierda
                {
                    filaHacia = filaDesde - 1;
                    columnaHacia = columnaDesde - 1;
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, ReinaB, tablero[filaHacia, columnaHacia]);
                    return;
                }
                else if (resultado == DialogResult.No && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover en diagonal hacia arriba-derecha
                {
                    filaHacia = filaDesde - 1;
                    columnaHacia = columnaDesde + 1;
                    RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, ReinaB, tablero[filaHacia, columnaHacia]);
                    return;
                }
                else if (resultado == DialogResult.Cancel && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia))
                {
                    return;
                }
            }
        }
        private void ReyN_Click(object sender, EventArgs e)
        {
            // Obtener la posición actual del rey en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(ReyN).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(ReyN).Column;

            // Pedir al jugador que seleccione la dirección de movimiento
            DialogResult resultado = MessageBox.Show("¿En qué dirección quieres mover el rey?", "Selecciona la dirección", MessageBoxButtons.YesNoCancel);

            int filaHacia = filaDesde;
            int columnaHacia = columnaDesde;

            // Movimiento del rey en función de la dirección seleccionada
            if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover hacia la izquierda
            {
                columnaHacia = columnaDesde - 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, ReyN, tablero[filaHacia, columnaHacia]);
                return;
            }
            else if (resultado == DialogResult.No && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover hacia la derecha
            {
                columnaHacia = columnaDesde + 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, ReyN, tablero[filaHacia, columnaHacia]);
                return;
            }
            else if (resultado == DialogResult.Cancel && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover hacia arriba
            {
                filaHacia = filaDesde + 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, ReyN, tablero[filaHacia, columnaHacia]);
                return;
            }

        }
        // Calcular la distancia vertical y horizontal entre la posición actual y la posición a la que se quiere mover

        private void ReyB_Click(object sender, EventArgs e)
        {
            // Obtener la posición actual del rey en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(ReyB).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(ReyB).Column;

            // Pedir al jugador que seleccione la dirección de movimiento
            DialogResult resultado = MessageBox.Show("¿En qué dirección quieres mover el rey?", "Selecciona la dirección", MessageBoxButtons.YesNoCancel);

            int filaHacia = filaDesde;
            int columnaHacia = columnaDesde;

            // Movimiento del rey en función de la dirección seleccionada
            if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover hacia la izquierda
            {
                columnaHacia = columnaDesde - 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, ReyB, tablero[filaHacia, columnaHacia]);
                return;
            }
            else if (resultado == DialogResult.No && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover hacia la derecha
            {
                columnaHacia = columnaDesde + 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, ReyB, tablero[filaHacia, columnaHacia]);
                return;
            }
            else if (resultado == DialogResult.Cancel && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover hacia arriba
            {
                filaHacia = filaDesde - 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, ReyB, tablero[filaHacia, columnaHacia]);
                return;
            }

        }
        private void CaballoN1_Click(object sender, EventArgs e)
        {
            // Obtener la posición actual del caballo en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(CaballoN1).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(CaballoN1).Column;

            // Pedir al jugador que seleccione la dirección de movimiento
            DialogResult resultado = MessageBox.Show("¿En qué dirección quieres mover el caballo?", "Selecciona la dirección", MessageBoxButtons.YesNoCancel);

            int filaHacia = filaDesde;
            int columnaHacia = columnaDesde;

            // L izquierda
            if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover hacia abajo
            {
                filaHacia = filaDesde + 2;
                columnaHacia = columnaDesde - 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, CaballoN1, tablero[filaHacia, columnaHacia]);
                return;
            }
            // L derecha
            else if (resultado == DialogResult.No && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover hacia abajo
            {
                filaHacia = filaDesde + 2;
                columnaHacia = columnaDesde + 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, CaballoN1, tablero[filaHacia, columnaHacia]);
                return;
            }
            else if (resultado == DialogResult.Cancel) // Mover hacia la izquierda
            {
                return;
            }

        }
        private void CaballoN2_Click(object sender, EventArgs e)
        {
            // Obtener la posición actual del caballo en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(CaballoN2).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(CaballoN2).Column;

            // Pedir al jugador que seleccione la dirección de movimiento
            DialogResult resultado = MessageBox.Show("¿En qué dirección quieres mover el caballo?", "Selecciona la dirección", MessageBoxButtons.YesNoCancel);

            int filaHacia = filaDesde;
            int columnaHacia = columnaDesde;

            // L izquierda
            if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover hacia abajo
            {
                filaHacia = filaDesde + 2;
                columnaHacia = columnaDesde - 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, CaballoN2, tablero[filaHacia, columnaHacia]);
                return;
            }
            // L derecha
            else if (resultado == DialogResult.No && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover hacia abajo
            {
                filaHacia = filaDesde + 2;
                columnaHacia = columnaDesde + 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, CaballoN2, tablero[filaHacia, columnaHacia]);
                return;
            }
            else if (resultado == DialogResult.Cancel) // Mover hacia la izquierda
            {
                return;
            }

        }
        private void CaballoB1_Click(object sender, EventArgs e)
        {
            // Obtener la posición actual del caballo en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(CaballoB1).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(CaballoB1).Column;

            // Pedir al jugador que seleccione la dirección de movimiento
            DialogResult resultado = MessageBox.Show("¿En qué dirección quieres mover el caballo?", "Selecciona la dirección", MessageBoxButtons.YesNoCancel);

            int filaHacia = filaDesde;
            int columnaHacia = columnaDesde;

            // L izquierda
            if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover hacia abajo
            {
                filaHacia = filaDesde - 2;
                columnaHacia = columnaDesde - 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, CaballoB1, tablero[filaHacia, columnaHacia]);
                return;
            }
            // L derecha
            else if (resultado == DialogResult.No && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover hacia abajo
            {
                filaHacia = filaDesde - 2;
                columnaHacia = columnaDesde + 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, CaballoB1, tablero[filaHacia, columnaHacia]);
                return;
            }
            else if (resultado == DialogResult.Cancel) // Mover hacia la izquierda
            {
                return;
            }

        }
        private void CaballoB2_Click(object sender, EventArgs e)
        {
            // Obtener la posición actual del caballo en el tablero
            int filaDesde = tableLayoutPanel1.GetPositionFromControl(CaballoB2).Row;
            int columnaDesde = tableLayoutPanel1.GetPositionFromControl(CaballoB2).Column;

            // Pedir al jugador que seleccione la dirección de movimiento
            DialogResult resultado = MessageBox.Show("¿En qué dirección quieres mover el caballo?", "Selecciona la dirección", MessageBoxButtons.YesNoCancel);

            int filaHacia = filaDesde;
            int columnaHacia = columnaDesde;

            // L izquierda
            if (resultado == DialogResult.Yes && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover hacia abajo
            {
                filaHacia = filaDesde - 2;
                columnaHacia = columnaDesde - 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, CaballoB2, tablero[filaHacia, columnaHacia]);
                return;
            }
            // L derecha
            else if (resultado == DialogResult.No && RangoPermitido(filaDesde, columnaDesde, filaHacia, columnaHacia)) // Mover hacia abajo
            {
                filaHacia = filaDesde - 2;
                columnaHacia = columnaDesde + 1;
                RealizarMovimiento(filaDesde, columnaDesde, filaHacia, columnaHacia, CaballoB2, tablero[filaHacia, columnaHacia]);
                return;
            }
            else if (resultado == DialogResult.Cancel) // Mover hacia la izquierda
            {
                return;
            }

        }

        private void CaballoN2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
