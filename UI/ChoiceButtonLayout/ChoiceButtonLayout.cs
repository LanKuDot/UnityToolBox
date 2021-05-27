namespace LanKuDot.UnityToolBox.UI.ChoiceButtonLayout
{
    public class ChoiceButtonLayout : ItemMatrixLayout<ChoiceButton>
    {
        private ChoiceButton[] _buttons;

        public void CreateButtons(object[] datas)
        {
            CreateItems(datas);
            // Convert the reference name
            _buttons = items;
        }

        /// <summary>
        /// Inactivate all the button except the specified id
        /// </summary>
        /// <param name="id">The id of the button that not to be inactivated</param>
        public void InactivateAllExcept(int id)
        {
            for (var i = 0; i < _buttons.Length; ++i) {
                if (i == id)
                    continue;

                _buttons[i].Inactivate();
            }
        }
    }
}
