using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Tool
    {
        protected IPaintApp app;

        protected event EventHandler MouseDownEvent;
        protected event EventHandler MouseUpEvent;
        protected event EventHandler MouseClickEvent;
        protected event EventHandler MouseMoveEvent;
        protected event EventHandler KeyDownEvent;

        public Tool(IPaintApp app)
        {
            this.app = app;
        }

        public void HandleEvent(EventType eventType, object sender, EventArgs e)
        {
            switch (eventType)
            {
                case EventType.MOUSEMOVE:
                    if (MouseMoveEvent != null)
                        MouseMoveEvent(sender, e);
                    break;
                case EventType.MOUSEUP:
                    if (MouseUpEvent != null)
                        MouseUpEvent(sender, e);
                    break;
                case EventType.MOUSEDOWN:
                    if (MouseDownEvent != null)
                        MouseDownEvent(sender, e);
                    break;
                case EventType.MOUSECLICK:
                    if (MouseClickEvent != null)
                        MouseClickEvent(sender, e);
                    break;
                case EventType.KEYDOWN:
                    if (KeyDownEvent != null)
                        KeyDownEvent(sender, e);
                    break;
            }
        }
    }
}
