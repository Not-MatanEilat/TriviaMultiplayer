using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices; // Install-Package Microsoft.VisualBasic

namespace Bootstrap
{

    namespace BSControl
    {

        public partial class BSControl : System.Windows.Forms.Control
        {

            private Color _borderColor;
            public Color BorderColor
            {
                get
                {
                    return _borderColor;
                }
                set
                {
                    if (_borderColor != value)
                    {
                        _borderColor = value;
                        OnBorderColorChanged();
                    }
                }
            }

            private bool _drawBorder;
            public bool DrawBorder
            {
                get
                {
                    return _drawBorder;
                }
                set
                {
                    if (_drawBorder != value)
                    {
                        _drawBorder = value;
                        OnDrawBorderChanged();
                    }
                }
            }

            protected virtual void OnBorderColorChanged()
            {
                BorderColorChanged?.Invoke(this, EventArgs.Empty);
            }

            protected virtual void OnDrawBorderChanged()
            {
                DrawBorderChanged?.Invoke(this, EventArgs.Empty);
            }

            public event BorderColorChangedEventHandler BorderColorChanged;

            public delegate void BorderColorChangedEventHandler(object sender, EventArgs e);
            public event DrawBorderChangedEventHandler DrawBorderChanged;

            public delegate void DrawBorderChangedEventHandler(object sender, EventArgs e);

            private void Control_BorderPropertiesChanged(object sender, EventArgs e)
            {
                this.Invalidate(true);
            }

            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateRoundRectRgn(int x1, int y1, int width, int height, int cx, int cy);

            public BSControl()
            {
                BorderColorChanged += Control_BorderPropertiesChanged;
                DrawBorderChanged += Control_BorderPropertiesChanged;
                this.Font = Utilities.Typography.Font();

                this.Region = Region.FromHrgn(BSControl.CreateRoundRectRgn(0, 0, this.Width, this.Height, Convert.ToInt32(Utilities.Typography.CalculateEM(this.Font) * 0.25d), Convert.ToInt32(Utilities.Typography.CalculateEM(this.Font) * 0.25d)));

                this.BackColor = Utilities.Color.BackgroundLight();
                this.ForeColor = Utilities.Color.TextBody();

                this.Padding = new Padding(Convert.ToInt32(Utilities.Typography.CalculateEM(this.Font) * 0.75d * 72d / 96d), Convert.ToInt32(Utilities.Typography.CalculateEM(this.Font) * 1.25d * 72d / 96d), Convert.ToInt32(Utilities.Typography.CalculateEM(this.Font) * 0.75d * 72d / 96d), Convert.ToInt32(Utilities.Typography.CalculateEM(this.Font) * 1.25d * 72d / 96d));

                BorderColor = this.BackColor;
                DrawBorder = false;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                int radius = Convert.ToInt32(Utilities.Typography.CalculateEM(this.Font) * 0.25d);
                Rectangle area = this.DisplayRectangle;
                var path = new System.Drawing.Drawing2D.GraphicsPath();

                area.Width -= 2;
                area.Height -= 2;

                path.AddArc(area.Left, area.Top, radius * 2, radius * 2, 180, 90); // Upper-Left
                path.AddArc(area.Right - radius * 2, area.Top, radius * 2, radius * 2, 270, 90); // Upper-Right
                path.AddArc(area.Right - radius * 2, area.Bottom - radius * 2, radius * 2, radius * 2, 0, 90); // Lower-Right
                path.AddArc(area.Left, area.Bottom - radius * 2, radius * 2, radius * 2, 90, 90); // Lower-Left
                path.CloseAllFigures();

                using (var pen = new Pen(_borderColor, 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }

            protected override void OnSizeChanged(EventArgs e)
            {
                base.OnSizeChanged(e);

                this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, Convert.ToInt32(Utilities.Typography.CalculateEM(this.Font) * 0.25d), Convert.ToInt32(Utilities.Typography.CalculateEM(this.Font) * 0.25d)));
            }
        }

        [DefaultEvent("IsDismissedChanged")]
        public partial class Alert : BSControl
        {

            public enum StyleType
            {
                Danger,
                Dark,
                Info,
                Light,
                Primary,
                Secondary,
                Success,
                Warning
            }

            private bool _dismissable;
            public bool Dismissable
            {
                get
                {
                    return _dismissable;
                }
                set
                {
                    if (_dismissable != value)
                    {
                        _dismissable = value;
                        OnDismissableChanged();
                    }
                }
            }

            private bool _fadable;
            public bool Fadable
            {
                get
                {
                    return _fadable;
                }
                set
                {
                    _fadable = value;
                }
            }

            private bool _isDismissed;
            public bool IsDismissed
            {
                get
                {
                    return _isDismissed;
                }
                set
                {
                    if (!_isDismissed.Equals(value))
                    {
                        _isDismissed = value;
                        OnIsDismissedChanged();
                    }
                }
            }

            private StyleType _style;
            public StyleType Style
            {
                get
                {
                    return _style;
                }
                set
                {
                    if (_style != value)
                    {
                        _style = value;
                        OnStyleChanged();
                    }
                }
            }

            protected virtual void OnDismissableChanged()
            {
                DismissableChanged?.Invoke(this, EventArgs.Empty);
            }

            protected virtual void OnIsDismissedChanged()
            {
                IsDismissedChanged?.Invoke(this, EventArgs.Empty);
            }

            protected virtual new void OnStyleChanged()
            {
                StyleChanged?.Invoke(this, EventArgs.Empty);
            }

            public event IsDismissedChangedEventHandler IsDismissedChanged;

            public delegate void IsDismissedChangedEventHandler(object sender, EventArgs e);

            public event DismissableChangedEventHandler DismissableChanged;

            public delegate void DismissableChangedEventHandler(object sender, EventArgs e);

            public new event StyleChangedEventHandler StyleChanged;

            public new delegate void StyleChangedEventHandler(object sender, EventArgs e);

            // Key: Style, Value: -> Key: BackgroundColor Value: Forecolor
            private Dictionary<StyleType, KeyValuePair<System.Drawing.Color, System.Drawing.Color>> styleConfiguration;

            public Alert() : base()
            {
                DismissableChanged += Alert_DismissableChanged;
                IsDismissedChanged += Alert_IsDismissedChanged;
                StyleChanged += Alert_StyleChanged;
                styleConfiguration = new Dictionary<StyleType, KeyValuePair<Color, Color>>();
                styleConfiguration.Add(StyleType.Danger, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(System.Drawing.Color.FromArgb(248, 215, 218), System.Drawing.Color.FromArgb(114, 28, 36)));
                styleConfiguration.Add(StyleType.Dark, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(System.Drawing.Color.FromArgb(198, 200, 202), System.Drawing.Color.FromArgb(27, 30, 33)));
                styleConfiguration.Add(StyleType.Info, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(System.Drawing.Color.FromArgb(209, 236, 241), System.Drawing.Color.FromArgb(12, 84, 96)));
                styleConfiguration.Add(StyleType.Light, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(System.Drawing.Color.FromArgb(254, 254, 254), System.Drawing.Color.FromArgb(129, 129, 130)));
                styleConfiguration.Add(StyleType.Primary, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(System.Drawing.Color.FromArgb(204, 229, 255), System.Drawing.Color.FromArgb(0, 64, 133)));
                styleConfiguration.Add(StyleType.Secondary, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(System.Drawing.Color.FromArgb(226, 227, 229), System.Drawing.Color.FromArgb(56, 61, 65)));
                styleConfiguration.Add(StyleType.Success, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(System.Drawing.Color.FromArgb(212, 237, 218), System.Drawing.Color.FromArgb(21, 87, 36)));
                styleConfiguration.Add(StyleType.Warning, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(System.Drawing.Color.FromArgb(255, 243, 205), System.Drawing.Color.FromArgb(133, 100, 4)));

                {
                    var withBlock = this;
                    withBlock.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                    withBlock.Dismissable = false;
                    withBlock.DoubleBuffered = true;
                    withBlock.Fadable = false;
                    withBlock.Style = StyleType.Primary;
                }
            }

            private void Alert_DismissableChanged(object sender, EventArgs e)
            {
                this.Invalidate(true);
            }

            private void Alert_IsDismissedChanged(object sender, EventArgs e)
            {
                this.Dispose(true);
            }

            protected override void OnMouseClick(MouseEventArgs e)
            {
                base.OnMouseClick(e);

                if (Dismissable && e.Button == MouseButtons.Left && this.MouseOverDismiss(e.X, e.Y))
                {
                    Dismiss();
                }
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);

                if (Dismissable && this.MouseOverDismiss(e.X, e.Y))
                {
                    this.Cursor = Cursors.Hand;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }

            protected override void OnPaddingChanged(EventArgs e)
            {
                base.OnPaddingChanged(e);

                this.Invalidate(true);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                int paddingTop = this.Padding.Top;
                int paddingRight = this.Padding.Right;
                if (Dismissable)
                {
                    using (Brush dismissBrush = new SolidBrush(styleConfiguration[Style].Value))
                    {
                        e.Graphics.DrawString(Utilities.Typography.Close(), Utilities.Typography.Font(), dismissBrush, new Point(this.Width - Convert.ToInt32(Utilities.Typography.CalculateEM(this.Font)) - 5, 5));
                        SizeF dismissSize = e.Graphics.MeasureString(Utilities.Typography.Close(), Utilities.Typography.Font());
                        if (dismissSize.Height + 5 > paddingTop)
                        {
                            paddingTop = Convert.ToInt32(dismissSize.Height) + 5;
                        }
                        if (dismissSize.Width + 5 > paddingRight)
                        {
                            paddingRight = Convert.ToInt32(dismissSize.Width) + 5;
                        }
                    }
                }

                Rectangle textBounds = this.DisplayRectangle;
                textBounds.Y += this.Padding.Top;
                textBounds.X += this.Padding.Left;
                textBounds.Width -= paddingRight + this.Padding.Right + this.Padding.Left;
                textBounds.Height -= this.Padding.Bottom + this.Padding.Top;

                TextRenderer.DrawText(e.Graphics, this.Text, this.Font, textBounds, this.ForeColor, TextFormatFlags.NoPadding | TextFormatFlags.Top | TextFormatFlags.WordBreak);

                base.OnPaint(e);
            }

            private void Alert_StyleChanged(object sender, EventArgs e)
            {
                {
                    var withBlock = styleConfiguration[Style];
                    this.BackColor = withBlock.Key;
                    BorderColor = withBlock.Key;
                    this.ForeColor = withBlock.Value;
                }
                this.Invalidate(true);
            }

            protected override void OnTextChanged(EventArgs e)
            {
                base.OnTextChanged(e);

                this.Invalidate(true);
            }

            public async void Dismiss()
            {
                if (Fadable)
                {
                    await Task.Run(() =>
                    {
                        this.SuspendLayout();
                        do
                        {
                            this.BackColor = Color.FromArgb(this.BackColor.A - 1, this.BackColor.R, this.BackColor.G, this.BackColor.B);
                            System.Threading.Thread.Sleep(byte.MaxValue / 150);
                        }
                        while (this.BackColor.A != 0);
                        this.ResumeLayout();
                    });
                }
                IsDismissed = Dismissable && !IsDismissed;
            }

            private bool MouseOverDismiss(int mouseX, int mouseY)
            {
                var closeDimensions = new SizeF(0, 0);

                using (Graphics closeGraphics = Graphics.FromHwnd(this.Handle))
                {
                    closeDimensions = closeGraphics.MeasureString(Utilities.Typography.Close(), this.Font);
                }

                return mouseX > this.Width - closeDimensions.Width && mouseY < closeDimensions.Height + 5;
            }

            public static DialogResult ShowDialog(string text)
            {
                return ShowDialog(text, StyleType.Primary, false);
            }

            public static DialogResult ShowDialog(string text, StyleType style)
            {
                return ShowDialog(text, style, false);
            }

            public static DialogResult ShowDialog(string text, StyleType style, bool fade)
            {
                DialogResult modalResult;

                using (var modal = new Form())
                {
                    var _alert = new Alert();
                    _alert.Dismissable = true;
                    _alert.Dock = DockStyle.Fill;
                    _alert.Fadable = fade;
                    _alert.Style = style;
                    _alert.Text = text;

                    _alert.IsDismissedChanged += (sender, e) =>
                    {
                        modal.DialogResult = DialogResult.OK;
                        modal.Close();
                    };

                    modal.Controls.Add(_alert);
                    modal.FormBorderStyle = FormBorderStyle.None;
                    modal.Size = new Size(300, 100);
                    modal.StartPosition = FormStartPosition.CenterParent;

                    modal.Load += (object sender, global::System.EventArgs e) => modal.Region = Region.FromHrgn(global::Bootstrap.BSControl.BSControl.CreateRoundRectRgn(0, 0, modal.Width, modal.Height, global::System.Convert.ToInt32(global::Bootstrap.Utilities.Typography.CalculateEM(_alert) * 0.25d), global::System.Convert.ToInt32(global::Bootstrap.Utilities.Typography.CalculateEM(_alert) * 0.25d)));

                    modalResult = modal.ShowDialog();
                }

                return modalResult;
            }

        }

        [DefaultEvent("Click")]
        public partial class BSButton : BSControl
        {

            public enum StyleType
            {
                Danger,
                Dark,
                Info,
                Light,
                Primary,
                Secondary,
                Success,
                Warning
            }

            private bool _isOutline;
            public bool IsOutline
            {
                get
                {
                    return _isOutline;
                }
                set
                {
                    if (!_isOutline.Equals(value))
                    {
                        _isOutline = value;
                        OnIsOutlineChanged();
                    }
                }
            }

            private StyleType _style;
            public StyleType Style
            {
                get
                {
                    return _style;
                }
                set
                {
                    if (_style != value)
                    {
                        _style = value;
                        OnStyleChanged();
                    }
                }
            }

            protected virtual void OnIsOutlineChanged()
            {
                IsOutlineChanged?.Invoke(this, EventArgs.Empty);
            }

            protected virtual new void OnStyleChanged()
            {
                StyleChanged?.Invoke(this, EventArgs.Empty);
            }

            public event IsOutlineChangedEventHandler IsOutlineChanged;

            public delegate void IsOutlineChangedEventHandler(object sender, EventArgs e);

            public new event StyleChangedEventHandler StyleChanged;

            public new delegate void StyleChangedEventHandler(object sender, EventArgs e);

            // Key: Style, Value: -> Key: BackgroundColor Value: Forecolor
            private Dictionary<StyleType, KeyValuePair<Color, Color>> styleConfiguration;

            // Key: Style, Value: -> Key: MouseEnter (hover) Value: MouseDown (active)
            private Dictionary<StyleType, KeyValuePair<Color, Color>> styleConfigurationMouseEvents;
            public BSButton()
            {
                StyleChanged += Button_StyleChanged;
                styleConfiguration = new Dictionary<StyleType, KeyValuePair<Color, Color>>();
                styleConfiguration.Add(StyleType.Danger, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(Utilities.Color.BackgroundDanger(), Utilities.Color.TextWhite()));
                styleConfiguration.Add(StyleType.Dark, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(Utilities.Color.BackgroundDark(), Utilities.Color.TextWhite()));
                styleConfiguration.Add(StyleType.Info, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(Utilities.Color.BackgroundInfo(), Utilities.Color.TextWhite()));
                styleConfiguration.Add(StyleType.Light, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(Utilities.Color.BackgroundLight(), Utilities.Color.TextBody()));
                styleConfiguration.Add(StyleType.Primary, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(Utilities.Color.BackgroundPrimary(), Utilities.Color.TextWhite()));
                styleConfiguration.Add(StyleType.Secondary, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(Utilities.Color.BackgroundSecondary(), Utilities.Color.TextWhite()));
                styleConfiguration.Add(StyleType.Success, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(Utilities.Color.BackgroundSuccess(), Utilities.Color.TextWhite()));
                styleConfiguration.Add(StyleType.Warning, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(Utilities.Color.BackgroundWarning(), Utilities.Color.TextBody()));

                styleConfigurationMouseEvents = new Dictionary<StyleType, KeyValuePair<Color, Color>>();
                styleConfigurationMouseEvents.Add(StyleType.Danger, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(Utilities.Color.HoverBackgroundDanger(), Utilities.Color.ActiveBackgroundDanger()));
                styleConfigurationMouseEvents.Add(StyleType.Dark, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(Utilities.Color.HoverBackgroundDark(), Utilities.Color.ActiveBackgroundDark()));
                styleConfigurationMouseEvents.Add(StyleType.Info, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(Utilities.Color.HoverBackgroundInfo(), Utilities.Color.ActiveBackgroundInfo()));
                styleConfigurationMouseEvents.Add(StyleType.Light, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(Utilities.Color.HoverBackgroundLight(), Utilities.Color.ActiveBackgroundLight()));
                styleConfigurationMouseEvents.Add(StyleType.Primary, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(Utilities.Color.HoverBackgroundPrimary(), Utilities.Color.ActiveBackgroundPrimary()));
                styleConfigurationMouseEvents.Add(StyleType.Secondary, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(Utilities.Color.HoverBackgroundSecondary(), Utilities.Color.ActiveBackgroundSecondary()));
                styleConfigurationMouseEvents.Add(StyleType.Success, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(Utilities.Color.HoverBackgroundSuccess(), Utilities.Color.ActiveBackgroundSuccess()));
                styleConfigurationMouseEvents.Add(StyleType.Warning, new KeyValuePair<System.Drawing.Color, System.Drawing.Color>(Utilities.Color.HoverBackgroundWarning(), Utilities.Color.ActiveBackgroundWarning()));

                {
                    var button = this;
                    ref var withBlock = ref button;
                    withBlock.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                    Style = StyleType.Primary;
                }
            }

            protected override void OnEnabledChanged(EventArgs e)
            {
                base.OnEnabledChanged(e);

                this.Invalidate(true);
            }

            private bool mouseDowned = false;
            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);
                mouseDowned = true;
                this.Invalidate(true);
            }

            protected override void OnMouseUp(MouseEventArgs e)
            {
                base.OnMouseDown(e);
                mouseDowned = false;
                this.Invalidate(true);
            }

            private bool mouseEntered = false;
            protected override void OnMouseEnter(EventArgs e)
            {
                base.OnMouseEnter(e);
                mouseEntered = true;
                this.Invalidate(true);
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                mouseEntered = false;
                this.Invalidate(true);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                Color textColor = this.ForeColor;
                Color backColor = this.BackColor;

                if (_isOutline)
                {
                    backColor = Color.FromArgb(Utilities.Color.BackgroundWhite().R, Utilities.Color.BackgroundWhite().G, Utilities.Color.BackgroundWhite().B);
                }
                else if (_isOutline && !mouseDowned && !mouseEntered)
                {
                    backColor = Utilities.Color.BackgroundWhite();
                }
                else if (!this.Enabled)
                {
                    backColor = Color.FromArgb(Convert.ToInt32(byte.MaxValue * 0.65d), backColor.R, backColor.G, backColor.B);
                }
                else if (mouseDowned)
                {
                    backColor = styleConfigurationMouseEvents[_style].Value;
                }
                else if (mouseEntered)
                {
                    backColor = styleConfigurationMouseEvents[_style].Key;
                }

                if (_isOutline)
                {
                    textColor = styleConfiguration[_style].Key;
                }

                if (_isOutline && (mouseDowned || mouseEntered))
                {
                    backColor = styleConfiguration[_style].Key;
                    textColor = Utilities.Color.TextWhite();
                    if (_style == StyleType.Warning || _style == StyleType.Light)
                    {
                        textColor = Utilities.Color.TextBody();
                    }
                }

                e.Graphics.Clear(backColor);

                TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.DisplayRectangle, textColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                base.OnPaint(e);
            }

            private void Button_StyleChanged(object sender, EventArgs e)
            {
                {
                    var withBlock = styleConfiguration[Style];
                    this.BackColor = withBlock.Key;
                    BorderColor = withBlock.Key;
                    this.ForeColor = withBlock.Value;
                }
                this.Invalidate(true);
            }

        }

        [DefaultEvent("CheckedChanged")]
        public partial class ToggleSwitch : BSControl
        {

            private bool _checked;
            public bool Checked
            {
                get
                {
                    return _checked;
                }
                set
                {
                    if (_checked != value)
                    {
                        _checked = value;
                        OnCheckedChanged();
                    }
                }
            }

            private Color _falseColor;
            public Color FalseColor
            {
                get
                {
                    return _falseColor;
                }
                set
                {
                    if (_falseColor != value)
                    {
                        _falseColor = value;
                        OnFalseColorChanged();
                    }
                }
            }

            private string _falseText;
            public string FalseText
            {
                get
                {
                    return _falseText;
                }
                set
                {
                    if ((_falseText ?? "") != (value ?? ""))
                    {
                        _falseText = value;
                        OnFalseTextChanged();
                    }
                }
            }

            private Color _trueColor;
            public Color TrueColor
            {
                get
                {
                    return _trueColor;
                }
                set
                {
                    if (_trueColor != value)
                    {
                        _trueColor = value;
                        OnTrueColorChanged();
                    }
                }
            }

            private string _trueText;
            public string TrueText
            {
                get
                {
                    return _trueText;
                }
                set
                {
                    if ((_trueText ?? "") != (value ?? ""))
                    {
                        _trueText = value;
                        OnTrueTextChanged();
                    }
                }
            }

            protected virtual void OnCheckedChanged()
            {
                this.Invalidate(true);
                CheckedChanged?.Invoke(this, EventArgs.Empty);
            }

            protected virtual void OnFalseColorChanged()
            {
                this.Invalidate(true);
                FalseColorChanged?.Invoke(this, EventArgs.Empty);
            }

            protected virtual void OnFalseTextChanged()
            {
                this.Invalidate(true);
                FalseTextChanged?.Invoke(this, EventArgs.Empty);
            }

            protected virtual void OnTrueColorChanged()
            {
                this.Invalidate(true);
                TrueColorChanged?.Invoke(this, EventArgs.Empty);
            }

            protected virtual void OnTrueTextChanged()
            {
                this.Invalidate(true);
                TrueTextChanged?.Invoke(this, EventArgs.Empty);
            }

            public event CheckedChangedEventHandler CheckedChanged;

            public delegate void CheckedChangedEventHandler(object sender, EventArgs e);
            public event FalseColorChangedEventHandler FalseColorChanged;

            public delegate void FalseColorChangedEventHandler(object sender, EventArgs e);
            public event FalseTextChangedEventHandler FalseTextChanged;

            public delegate void FalseTextChangedEventHandler(object sender, EventArgs e);
            public event TrueColorChangedEventHandler TrueColorChanged;

            public delegate void TrueColorChangedEventHandler(object sender, EventArgs e);
            public event TrueTextChangedEventHandler TrueTextChanged;

            public delegate void TrueTextChangedEventHandler(object sender, EventArgs e);

            public ToggleSwitch()
            {
                BorderColor = Utilities.Color.TextBody();
                this.ForeColor = Utilities.Color.TextWhite();
                _checked = true;
                _falseColor = Utilities.Color.BackgroundDanger();
                _falseText = "Off";
                _trueColor = Utilities.Color.BackgroundSuccess();
                _trueText = "On";
            }

            protected override void OnMouseClick(MouseEventArgs e)
            {
                base.OnMouseClick(e);

                _checked = !_checked;
                OnCheckedChanged();
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);

                int halfControlWidth = Convert.ToInt32(this.Width / 2);
                if (_checked && e.X > halfControlWidth || !_checked && e.X < halfControlWidth)
                {
                    this.Cursor = Cursors.Hand;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                int halfControlWidth = Convert.ToInt32(this.Width / 2);
                var sliderRectangle = new Rectangle(!_checked ? halfControlWidth : 0, 0, halfControlWidth, this.Height);
                using (Brush sliderBorderBrush = new SolidBrush(Utilities.Color.BackgroundLight()))
                {
                    e.Graphics.FillRectangle(sliderBorderBrush, sliderRectangle);
                }

                sliderRectangle.Y += 1;
                sliderRectangle.Height -= 4;
                using (Brush sliderBackgroundBrush = new SolidBrush(_checked ? _trueColor : _falseColor))
                {
                    e.Graphics.FillRectangle(sliderBackgroundBrush, sliderRectangle);
                }

                using (var toggleBorderPen = new Pen(BorderColor, 1))
                {
                    e.Graphics.DrawLine(toggleBorderPen, new Point(halfControlWidth, 0), new Point(halfControlWidth, this.Height));
                }

                TextRenderer.DrawText(e.Graphics, _checked ? _trueText : _falseText, this.Font, this.DisplayRectangle, this.ForeColor, TextFormatFlags.LeftAndRightPadding | TextFormatFlags.VerticalCenter | (_checked ? TextFormatFlags.Left : TextFormatFlags.Right));

            }

            protected override void OnSizeChanged(EventArgs e)
            {
                base.OnSizeChanged(e);
                this.Invalidate(true);
            }

        }

    }

    namespace Utilities
    {

        public static partial class Color
        {

            public static System.Drawing.Color ActiveBackgroundDanger()
            {
                return System.Drawing.Color.FromArgb(189, 33, 48);
            }

            public static System.Drawing.Color ActiveBackgroundDark()
            {
                return System.Drawing.Color.FromArgb(29, 33, 36);
            }

            public static System.Drawing.Color ActiveBackgroundInfo()
            {
                return System.Drawing.Color.FromArgb(17, 122, 139);
            }

            public static System.Drawing.Color ActiveBackgroundLight()
            {
                return System.Drawing.Color.FromArgb(218, 224, 229);
            }

            public static System.Drawing.Color ActiveBackgroundPrimary()
            {
                return System.Drawing.Color.FromArgb(0, 98, 204);
            }

            public static System.Drawing.Color ActiveBackgroundSecondary()
            {
                return System.Drawing.Color.FromArgb(84, 91, 98);
            }

            public static System.Drawing.Color ActiveBackgroundSuccess()
            {
                return System.Drawing.Color.FromArgb(30, 126, 52);
            }

            public static System.Drawing.Color ActiveBackgroundWarning()
            {
                return System.Drawing.Color.FromArgb(211, 158, 0);
            }

            public static System.Drawing.Color BackgroundDanger()
            {
                return System.Drawing.Color.FromArgb(220, 53, 69);
            }

            public static System.Drawing.Color BackgroundDark()
            {
                return System.Drawing.Color.FromArgb(52, 58, 64);
            }

            public static System.Drawing.Color BackgroundInfo()
            {
                return System.Drawing.Color.FromArgb(23, 162, 184);
            }

            public static System.Drawing.Color BackgroundLight()
            {
                return System.Drawing.Color.FromArgb(248, 249, 250);
            }

            public static System.Drawing.Color BackgroundPrimary()
            {
                return System.Drawing.Color.FromArgb(0, 123, 255);
            }

            public static System.Drawing.Color BackgroundSecondary()
            {
                return System.Drawing.Color.FromArgb(108, 117, 125);
            }

            public static System.Drawing.Color BackgroundSuccess()
            {
                return System.Drawing.Color.FromArgb(40, 167, 69);
            }

            public static System.Drawing.Color BackgroundWarning()
            {
                return System.Drawing.Color.FromArgb(255, 193, 7);
            }

            public static System.Drawing.Color BackgroundWhite()
            {
                return System.Drawing.Color.FromArgb(255, 255, 255);
            }

            public static System.Drawing.Color HoverBackgroundDanger()
            {
                return System.Drawing.Color.FromArgb(200, 35, 51);
            }

            public static System.Drawing.Color HoverBackgroundDark()
            {
                return System.Drawing.Color.FromArgb(35, 39, 43);
            }

            public static System.Drawing.Color HoverBackgroundInfo()
            {
                return System.Drawing.Color.FromArgb(19, 132, 150);
            }

            public static System.Drawing.Color HoverBackgroundLight()
            {
                return System.Drawing.Color.FromArgb(226, 230, 234);
            }

            public static System.Drawing.Color HoverBackgroundPrimary()
            {
                return System.Drawing.Color.FromArgb(0, 105, 217);
            }

            public static System.Drawing.Color HoverBackgroundSecondary()
            {
                return System.Drawing.Color.FromArgb(90, 98, 104);
            }

            public static System.Drawing.Color HoverBackgroundSuccess()
            {
                return System.Drawing.Color.FromArgb(33, 136, 56);
            }

            public static System.Drawing.Color HoverBackgroundWarning()
            {
                return System.Drawing.Color.FromArgb(224, 168, 0);
            }

            public static System.Drawing.Color[] EnumerateBackgroundColors()
            {
                return new[] { BackgroundDanger(), BackgroundDark(), BackgroundInfo(), BackgroundLight(), BackgroundPrimary(), BackgroundSecondary(), BackgroundSuccess(), BackgroundWarning(), BackgroundWhite() };
            }

            public static System.Drawing.Color[] EnumerateHoverBackgroundColors()
            {
                return new[] { HoverBackgroundDanger(), HoverBackgroundDark(), HoverBackgroundInfo(), HoverBackgroundLight(), HoverBackgroundPrimary(), HoverBackgroundSecondary(), HoverBackgroundSuccess(), HoverBackgroundWarning() };
            }

            public static System.Drawing.Color[] EnumerateTextColors()
            {
                return new[] { TextBlack50(), TextBody(), TextDanger(), TextDark(), TextInfo(), TextLight(), TextMuted(), TextPrimary(), TextSecondary(), TextSuccess(), TextWarning(), TextWhite(), TextWhite50() };
            }

            public static System.Drawing.Color TextBlack50()
            {
                return System.Drawing.Color.FromArgb(byte.MaxValue / 2, 0, 0, 0);
            }

            public static System.Drawing.Color TextBody()
            {
                return System.Drawing.Color.FromArgb(33, 37, 41);
            }

            public static System.Drawing.Color TextDanger()
            {
                return System.Drawing.Color.FromArgb(220, 53, 69);
            }

            public static System.Drawing.Color TextDark()
            {
                return System.Drawing.Color.FromArgb(52, 58, 64);
            }

            public static System.Drawing.Color TextInfo()
            {
                return System.Drawing.Color.FromArgb(23, 162, 184);
            }

            public static System.Drawing.Color TextLight()
            {
                return System.Drawing.Color.FromArgb(248, 249, 250);
            }

            public static System.Drawing.Color TextMuted()
            {
                return System.Drawing.Color.FromArgb(108, 117, 125);
            }

            public static System.Drawing.Color TextPrimary()
            {
                return System.Drawing.Color.FromArgb(0, 123, 255);
            }

            public static System.Drawing.Color TextSecondary()
            {
                return System.Drawing.Color.FromArgb(108, 117, 125);
            }

            public static System.Drawing.Color TextSuccess()
            {
                return System.Drawing.Color.FromArgb(40, 167, 69);
            }

            public static System.Drawing.Color TextWarning()
            {
                return System.Drawing.Color.FromArgb(255, 193, 7);
            }

            public static System.Drawing.Color TextWhite()
            {
                return System.Drawing.Color.FromArgb(255, 255, 255);
            }

            public static System.Drawing.Color TextWhite50()
            {
                return System.Drawing.Color.FromArgb(byte.MaxValue / 2, 0, 0, 0);
            }

        }

        public static partial class Typography
        {

            /// <summary>
            /// Calculates the "EM" of a given font.
            /// </summary>
            /// <param name="font">The font to measure.</param>
            /// <returns>The width of the letter 'M' of a given font, in pixels.</returns>
            public static double CalculateEM(Font font)
            {
                if (font is null)
                {
                    throw new ArgumentNullException("Font cannot be null.");
                }

                return TextRenderer.MeasureText("M", font).Width;
            }

            /// <summary>
            /// Calculates the "EM" of a given control's font.
            /// </summary>
            /// <param name="control">The control who' font to measure.</param>
            /// <returns>The width of the letter 'M' of a given control's font, in pixels.</returns>
            public static double CalculateEM(System.Windows.Forms.Control control)
            {
                if (control is null)
                {
                    throw new ArgumentNullException("BSControl cannot be null.");
                }

                return TextRenderer.MeasureText("M", control.Font).Width;
            }

            /// <summary>
            /// Calculates the root "EM" of a given control's font.
            /// </summary>
            /// <param name="control">The control who' font to measure.</param>
            /// <returns>The width of the letter 'M' of a given control's form's font, in pixels.</returns>
            public static double CalculateREM(System.Windows.Forms.Control control)
            {
                if (control is null)
                {
                    throw new ArgumentNullException("BSControl cannot be null.");
                }
                Form rootElement = control.FindForm();
                if (rootElement is null)
                {
                    throw new ArgumentNullException("The form on which the control resides on cannot be null.");
                }

                return TextRenderer.MeasureText("M", rootElement.Font).Width;
            }

            /// <summary>
            /// Gets the unicode character for the dismiss/close icon
            /// </summary>
            /// <returns>String</returns>
            public static string Close()
            {
                return Convert.ToChar(10005).ToString();
            }

            /// <summary>
            /// Gets the default font that bootstrap uses based on the fonts that the current machine has
            /// </summary>
            /// <returns>Sans-Serif font at 16px</returns>
            public static Font Font()
            {
                return new Font(FontStack().First(), 16, GraphicsUnit.Pixel);
            }

            /// <summary>
            /// Gets the installed fonts on the current machine that bootstrap uses.
            /// </summary>
            /// <returns>Font array</returns>
            /// <remarks>For more information on font stacks, visit: https://www.smashingmagazine.com/2009/09/complete-guide-to-css-font-stacks/</remarks>
            public static FontFamily[] FontStack()
            {
                var installedFamilies = new List<FontFamily>();
                var fontCollection = new InstalledFontCollection();

                if (fontCollection.Families.Any(family => Operators.ConditionalCompareObjectEqual(family.Name, "Segoe UI", false)))
                {
                    installedFamilies.Add(new FontFamily("Segoe UI"));
                }
                if (fontCollection.Families.Any(family => Operators.ConditionalCompareObjectEqual(family.Name, "Roboto", false)))
                {
                    installedFamilies.Add(new FontFamily("Roboto"));
                }
                if (fontCollection.Families.Any(family => Operators.ConditionalCompareObjectEqual(family.Name, "Helvetica Neue", false)))
                {
                    installedFamilies.Add(new FontFamily("Helvetica Neue"));
                }

                installedFamilies.Add(FontFamily.GenericSansSerif);

                return installedFamilies.ToArray();
            }

            /// <summary>
            /// Gets the default monospace font that bootstrap uses based on the fonts that the current machine has
            /// </summary>
            /// <returns>Monospace font at 16px</returns>
            public static Font Monospace()
            {
                return new Font(MonospaceStack().First(), 16, GraphicsUnit.Pixel);
            }

            /// <summary>
            /// Gets the installed fonts on the current machine that bootstrap uses for monospace fonts.
            /// </summary>
            /// <returns>Font array</returns>
            /// <remarks>For more information on font stacks, visit: https://www.smashingmagazine.com/2009/09/complete-guide-to-css-font-stacks/</remarks>
            public static FontFamily[] MonospaceStack()
            {
                var installedFamilies = new List<FontFamily>();
                var fontCollection = new InstalledFontCollection();

                if (fontCollection.Families.Any(family => Operators.ConditionalCompareObjectEqual(family.Name, "SFMono-Regular", false)))
                {
                    installedFamilies.Add(new FontFamily("SFMono-Regular"));
                }
                if (fontCollection.Families.Any(family => Operators.ConditionalCompareObjectEqual(family.Name, "Menlo", false)))
                {
                    installedFamilies.Add(new FontFamily("Menlo"));
                }
                if (fontCollection.Families.Any(family => Operators.ConditionalCompareObjectEqual(family.Name, "Monaco", false)))
                {
                    installedFamilies.Add(new FontFamily("Monaco"));
                }
                if (fontCollection.Families.Any(family => Operators.ConditionalCompareObjectEqual(family.Name, "Consolas", false)))
                {
                    installedFamilies.Add(new FontFamily("Consolas"));
                }
                if (fontCollection.Families.Any(family => Operators.ConditionalCompareObjectEqual(family.Name, "Liberation Mono", false)))
                {
                    installedFamilies.Add(new FontFamily("Liberation Mono"));
                }
                if (fontCollection.Families.Any(family => Operators.ConditionalCompareObjectEqual(family.Name, "Courier New", false)))
                {
                    installedFamilies.Add(new FontFamily("Courier New"));
                }
                installedFamilies.Add(FontFamily.GenericMonospace);

                return installedFamilies.ToArray();
            }

        }

    }

}