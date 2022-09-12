using System.Collections.Generic;

namespace BusinessLogic.Models
{
    // a simple model for grouped user-data presentation

    public class DisplayGroupedData
    {
        #region public vars

        public string TitleValue { get; private set; }
        public List<string> ListValues { get; private set; }

        #endregion

        #region public methods

        public DisplayGroupedData(string titleValue, List<string> listValues)
        {
            TitleValue = titleValue;
            ListValues = listValues;
        }

        #endregion
    }
}
