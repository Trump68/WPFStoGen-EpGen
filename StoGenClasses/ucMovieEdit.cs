using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace StoGen.Classes
{
    public partial class ucMovieEdit : UserControl
    {
        public ucMovieEdit()
        {
            InitializeComponent();

            Array a = Enum.GetValues(typeof(CountryEnum));
            foreach (int item in a)
            {
                this.cbCountry.Properties.Items.Add(new ImageComboBoxItem(Enum.GetName(typeof(CountryEnum),item), (CountryEnum)item,-1));
            }
            this.cbCountry.SelectedIndex = 0;

            a = Enum.GetValues(typeof(GenreTypeEnum));
            foreach (int item in a)
            {
                this.cbGenreType.Properties.Items.Add(new ImageComboBoxItem(Enum.GetName(typeof(GenreTypeEnum), item), (GenreTypeEnum)item, -1));
            }
            this.cbGenreType.SelectedIndex = 0;


            a = Enum.GetValues(typeof(GenreEnum));
            foreach (int item in a)
            {
                this.cbGenre.Properties.Items.Add(new ImageComboBoxItem(Enum.GetName(typeof(GenreEnum), item), (GenreEnum)item, -1));
            }
            this.cbGenre.SelectedIndex = 0;

            a = Enum.GetValues(typeof(ProductionTypeEnum));
            foreach (int item in a)
            {
                this.cbProductionType.Properties.Items.Add(new ImageComboBoxItem(Enum.GetName(typeof(ProductionTypeEnum), item), (ProductionTypeEnum)item, -1));
            }
            this.cbProductionType.SelectedIndex = 0;
        }
        internal SgMovie CurrentMovie;
        public void SetMovie(SgMovie m)
        {
            CurrentMovie = m;
            seId.Text = $"{m.Id}";
            teName.Text = m.Name;
            teAliace.Text = m.Aliace;
            seYear.Value = m.ProductionYear;
            cbGenre.EditValue = m.Genre;
            cbGenreType.EditValue = m.GenreType;
            cbCountry.EditValue = m.Country;
            teStudio.Text = m.Studio?.Trim();
            teDirector.Text = m.Director?.Trim();
            seScore.Value = m.Score;
            cbProductionType.EditValue = m.ProductionType;
            teSerieName.Text = m.SerieName;
            seSerialSeason.Value = m.SerieSeason;
            seSerialEpisode.Value = m.SerieEpisode;
            meDescrShort.Text = m.DescriptionShort;
            meDescrFull.Text = m.DescriptionLong;
        }
        public SgMovie GetMovie()
        {
            CurrentMovie.Name = teName.Text;
            CurrentMovie.Aliace = teAliace.Text;
            CurrentMovie.ProductionYear = (int)seYear.Value;
            CurrentMovie.Genre = (GenreEnum)cbGenre.EditValue;
            CurrentMovie.GenreType = (GenreTypeEnum)cbGenreType.EditValue;
            CurrentMovie.Country = (CountryEnum)cbCountry.EditValue;
            CurrentMovie.Studio = teStudio.Text;
            CurrentMovie.Director = teDirector.Text;
            CurrentMovie.Score = (int)seScore.Value;
            CurrentMovie.ProductionType = (ProductionTypeEnum)cbProductionType.EditValue;
            CurrentMovie.SerieName = teSerieName.Text;
            CurrentMovie.SerieSeason = (int)seSerialSeason.Value;
            CurrentMovie.SerieEpisode = (int)seSerialEpisode.Value;
            CurrentMovie.DescriptionShort = meDescrShort.Text;
            CurrentMovie.DescriptionLong = meDescrFull.Text;
            return this.CurrentMovie;
        }
    }
}
