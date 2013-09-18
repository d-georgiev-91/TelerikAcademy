using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class MouseInterface : IUserInterface
    {
        public event EventHandler OnLeftPressed;

        public event EventHandler OnRightPressed;

        public event EventHandler OnActionPressed;

        private int lastMouseX = System.Windows.Forms.Cursor.Position.X;
        private int lastMouseY = System.Windows.Forms.Cursor.Position.Y;

        public void ProcessInput()
        {
            int currMouseX = System.Windows.Forms.Cursor.Position.X;
            int currMouseY = System.Windows.Forms.Cursor.Position.Y;

            if (currMouseX - lastMouseX > 0)
            {
                OnRightPressed(this, new EventArgs());
            }

            if (currMouseX - lastMouseX < 0)
            {
                OnLeftPressed(this, new EventArgs());
            }
            lastMouseX = currMouseX;
            lastMouseY = currMouseY;
        }
    }
}
