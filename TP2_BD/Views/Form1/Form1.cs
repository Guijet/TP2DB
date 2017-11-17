using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_BD
{
    public partial class Form1 : Form
    {
        Color selectedColorPNL = System.Drawing.ColorTranslator.FromHtml("#727272");
        Color selectedColorText = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

        Color unselectedColorPNL = System.Drawing.ColorTranslator.FromHtml("#939393");
        Color unselectedColorText = System.Drawing.ColorTranslator.FromHtml("#000000");
        bool isFirstLoading;
        public Form1()
        {
            InitializeComponent();
            isFirstLoading = true;
            CB_Moniteur.Enabled = false;
            //PANEL COLORS SET UPS
            setMainpanel();
            setPNLColors();
            HideAllPNL();
            PNLContainer_P1.Show();
            setUpCB();
            fillAllCB();
            setUpDGVEtudiantWithStage();
            LBL_NbStageByEnt.Text = "";
        }



        //POUR ACCEDER AU ID D'UN COMBOBOX
        //(CB_Entreprise.SelectedItem as ItemsCB).getId().ToString()
        #region filling ComboBox Section

        void setUpCB()
        {
            CB_Entreprise.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_EntrepriseStage.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Moniteur.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_StageNewDes.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_StageSupprimer.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Stagiaire.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        void fillAllCB()
        {
            //FILLING AND GETTING INFORMATION FOR COMBOBOXES
            fillCBEntreprise(CB_Entreprise);
            fillCBEntreprise(CB_EntrepriseStage);
            fillCBEntreprise(comboBox1);
            fillCBMoniteur(CB_Moniteur);
            fillCBStagiaire(CB_Stagiaire);
            fillCBStages(CB_StageSupprimer);
            fillCBStages(CB_StageNewDes);
        }

        

        void fillCBEntreprise(ComboBox cb)
        {
            List<Entreprise> listeEnt = Procedure.getAllEnt(Connection.sqlconnect);
            foreach (var ent in listeEnt)
            {
                cb.Items.Add(new ItemsCB(ent.getName(), ent.getID()));
            }
        }

        void fillCBStagiaire(ComboBox cb)
        {
            List<Stagiaire> listeStagiaire = Procedure.getAllStagiaire(Connection.sqlconnect);

            foreach (var stagiaire in listeStagiaire)
            {            
                cb.Items.Add(new ItemsCB(stagiaire.getName() + " " + stagiaire.getLastname(), stagiaire.getID()));
            }
        }

        void fillCBMoniteur(ComboBox cb)
        {
            List<Moniteur> listeMoniteur = Procedure.getAllMoniteur(Connection.sqlconnect);

            foreach(var moniteur in listeMoniteur)
            {
                cb.Items.Add(new ItemsCB(moniteur.getName() + " " + moniteur.getLastName(), moniteur.getId()));
            }
        }
        
        void fillCBStages(ComboBox cb)
        {
            List<Stage> listeStage = Procedure.getAllStage(Connection.sqlconnect);

            foreach(var stage in listeStage)
            {
                cb.Items.Add(new ItemsCB(stage.getPlateformes() + " ," + stage.getLanguages(), stage.getId()));
            }
        }
        #endregion

        #region PanelSetUps
        void setMainpanel()
        {
            Main_PNL.BackColor = System.Drawing.ColorTranslator.FromHtml("#939393");
            PNLContainer_P1.BackColor = System.Drawing.ColorTranslator.FromHtml("#939393");
            PNLContainer_P2.BackColor = System.Drawing.ColorTranslator.FromHtml("#939393");
            PNLContainer_P3.BackColor = System.Drawing.ColorTranslator.FromHtml("#939393");
            PNLContainer_P41.BackColor = System.Drawing.ColorTranslator.FromHtml("#939393");
            PNLContainer_P5.BackColor = System.Drawing.ColorTranslator.FromHtml("#939393");
            PNLContainer_P6.BackColor = System.Drawing.ColorTranslator.FromHtml("#939393");
        }

        void setPNLColors()
        {
            PNL_P1.BackColor = selectedColorPNL;
            LBL_P1.ForeColor = selectedColorText;

            PNL_P2.BackColor = unselectedColorPNL;
            LBL_P2.ForeColor = unselectedColorText;

            PNL_P3.BackColor = unselectedColorPNL;
            LBL_P3.ForeColor = unselectedColorText;

            PNL_P4.BackColor = unselectedColorPNL;
            LBL_P4.ForeColor = unselectedColorText;

            PNL_P5.BackColor = unselectedColorPNL;
            LBL_P5.ForeColor = unselectedColorText;

            PNL_P6.BackColor = unselectedColorPNL;
            LBL_P6.ForeColor = unselectedColorText;
        }

        private void LBL_P1_Click(object sender, EventArgs e)
        {
            resetAllPNLAndLBL();
            PNL_P1.BackColor = selectedColorPNL;
            LBL_P1.ForeColor = selectedColorText;
            HideAllPNL();
            PNLContainer_P1.Show();
        }

        private void LBL_P2_Click(object sender, EventArgs e)
        {
            resetAllPNLAndLBL();
            PNL_P2.BackColor = selectedColorPNL;
            LBL_P2.ForeColor = selectedColorText;
            HideAllPNL();
            PNLContainer_P2.Show();
        }

        private void LBL_P3_Click(object sender, EventArgs e)
        {
            resetAllPNLAndLBL();
            PNL_P3.BackColor = selectedColorPNL;
            LBL_P3.ForeColor = selectedColorText;
            HideAllPNL();
            PNLContainer_P3.Show();
        }

        private void LBL_P4_Click(object sender, EventArgs e)
        {
            resetAllPNLAndLBL();
            PNL_P4.BackColor = selectedColorPNL;
            LBL_P4.ForeColor = selectedColorText;
            HideAllPNL();
            PNLContainer_P41.Show();
        }

        private void LBL_P5_Click(object sender, EventArgs e)
        {
            resetAllPNLAndLBL();
            PNL_P5.BackColor = selectedColorPNL;
            LBL_P5.ForeColor = selectedColorText;
            HideAllPNL();
            PNLContainer_P5.Show();
        }

        private void LBL_P6_Click(object sender, EventArgs e)
        {
            resetAllPNLAndLBL();
            PNL_P6.BackColor = selectedColorPNL;
            LBL_P6.ForeColor = selectedColorText;
            HideAllPNL();
            PNLContainer_P6.Show();
        }


        private void PNL_P1_Click(object sender, EventArgs e)
        {
            resetAllPNLAndLBL();
            PNL_P1.BackColor = selectedColorPNL;
            LBL_P1.ForeColor = selectedColorText;
            HideAllPNL();
            PNLContainer_P1.Show();
        }

        private void PNL_P2_Click(object sender, EventArgs e)
        {
            resetAllPNLAndLBL();
            PNL_P2.BackColor = selectedColorPNL;
            LBL_P2.ForeColor = selectedColorText;
            HideAllPNL();
            PNLContainer_P2.Show();
        }

        private void PNL_P3_Click(object sender, EventArgs e)
        {
            resetAllPNLAndLBL();
            PNL_P3.BackColor = selectedColorPNL;
            LBL_P3.ForeColor = selectedColorText;
            HideAllPNL();
            PNLContainer_P3.Show();
        }

        private void PNL_P4_Click(object sender, EventArgs e)
        {
            resetAllPNLAndLBL();
            PNL_P4.BackColor = selectedColorPNL;
            LBL_P4.ForeColor = selectedColorText;
            HideAllPNL();
            PNLContainer_P41.Show();
        }

        private void PNL_P5_Click(object sender, EventArgs e)
        {
            resetAllPNLAndLBL();
            PNL_P5.BackColor = selectedColorPNL;
            LBL_P5.ForeColor = selectedColorText;
            HideAllPNL();
            PNLContainer_P5.Show();
        }

        private void PNL_P6_Click(object sender, EventArgs e)
        {
            resetAllPNLAndLBL();
            PNL_P6.BackColor = selectedColorPNL;
            LBL_P6.ForeColor = selectedColorText;
            HideAllPNL();
            PNLContainer_P6.Show();
        }


        void resetAllPNLAndLBL()
        {
            PNL_P1.BackColor = unselectedColorPNL;
            LBL_P1.ForeColor = unselectedColorText;

            PNL_P2.BackColor = unselectedColorPNL;
            LBL_P2.ForeColor = unselectedColorText;

            PNL_P3.BackColor = unselectedColorPNL;
            LBL_P3.ForeColor = unselectedColorText;

            PNL_P4.BackColor = unselectedColorPNL;
            LBL_P4.ForeColor = unselectedColorText;

            PNL_P5.BackColor = unselectedColorPNL;
            LBL_P5.ForeColor = unselectedColorText;

            PNL_P6.BackColor = unselectedColorPNL;
            LBL_P6.ForeColor = unselectedColorText;
        }
        void HideAllPNL()
        {
            PNLContainer_P1.Hide();
            PNLContainer_P2.Hide();
            PNLContainer_P3.Hide();
            PNLContainer_P41.Hide();
            PNLContainer_P5.Hide();
            PNLContainer_P6.Hide();
        }
        #endregion

        //
        //
        //MODIFIER LA DESCRIPTION D'UN STAGE
        //
        //

        private void BTN_ModifierDes_Click(object sender, EventArgs e)
        {
            if (!TB_NewDescription.Text.Equals("") && !CB_StageNewDes.Text.Equals(""))
            {
                Procedure.modifyDescription(Connection.sqlconnect, (CB_StageNewDes.SelectedItem as ItemsCB).getId(), TB_NewDescription.Text);
                //EMPTY FORM
                TB_NewDescription.Text = "";
                CB_StageNewDes.SelectedText = "";
                //RELOAD CB
                reloadStageCB();
                
            }
            else
            {
                MessageBox.Show("Vous devez remplir tout les champs pour modifier la descrription");
            }
        }

        #region Handle Moniteur By Stage and update data or lock CB
        private void CB_Entreprise_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Entreprise.Text.Equals(""))
            {
                CB_Moniteur.Enabled = false;
            }
            else
            {
                CB_Moniteur.Enabled = true;
                CB_Moniteur.SelectedText.Equals("");
                updateCbMoniteur();
            }
            
        }

        void updateCbMoniteur()
        {
           
            CB_Moniteur.Items.Clear();
            List<Moniteur> listeMoniteur = Procedure.getAllMoniteurByEnt(Connection.sqlconnect, (CB_Entreprise.SelectedItem as ItemsCB).getId());

            foreach(var moniteur in listeMoniteur)
            {
                CB_Moniteur.Items.Add(new ItemsCB(moniteur.getName() + " " + moniteur.getLastName(), moniteur.getId()));
            }
            
        }
        #endregion

        //
        //
        //AJOUT D'UN STAGE
        //
        //

        private void BTN_AddStage_Click(object sender, EventArgs e)
        {
            if(!CB_Entreprise.Text.Equals("") && !CB_Moniteur.Text.Equals("") && !CB_Stagiaire.Text.Equals("") && !TB_Description.Text.Equals("") && !TB_TypeETG.Text.Equals("") && !TB_Language.Text.Equals("") && !TB_Plateforme.Text.Equals(""))
            {
                Procedure.addStage(Connection.sqlconnect, (CB_Entreprise.SelectedItem as ItemsCB).getId(), (CB_Moniteur.SelectedItem as ItemsCB).getId(), (CB_Stagiaire.SelectedItem as ItemsCB).getId(), TB_Description.Text, TB_TypeETG.Text, TB_Language.Text, TB_Plateforme.Text);
                //EMPTY FORM
                CB_Entreprise.Text = "";
                CB_Moniteur.Text = "";
                CB_Stagiaire.Text = "";
          

                TB_Description.Text = "";
                TB_Language.Text = "";
                TB_TypeETG.Text = "";
                TB_Plateforme.Text = "";
                CB_Moniteur.Enabled = false;
                //RELOAD STAGES IN CB
                reloadStageCB();
            }
            else
            {
                MessageBox.Show("Vous devez remplir tout les champs pour ajouter un stage");
            }
        }

        //
        //
        //SUPPRESSION D'UN STAGE
        //
        //
        private void BTN_SupprimerStage_Click(object sender, EventArgs e)
        {
            if(!CB_StageSupprimer.Text.Equals(""))
            {
                Procedure.deleteStage(Connection.sqlconnect, (CB_StageSupprimer.SelectedItem as ItemsCB).getId());
                CB_StageSupprimer.Text = "";
                reloadStageCB();
            }
            else
            {
                MessageBox.Show("Vous devez selectionner un stage pour en supprimer!");
            }
        }

        //
        //
        //Nombre de stage par entreprise lorsque index change dans le combobox
        //
        //
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LBL_NbStageByEnt.Text = Procedure.getNbStagesByEntreprise(Connection.sqlconnect, (comboBox1.SelectedItem as ItemsCB).getId()).ToString();
        }

        void setUpDGVEtudiantWithStage()
        {
            //REFRESH WHEN DELETING AND CREATING STAGE
            Procedure.getEtudiantWithStage(Connection.sqlconnect, DGV_Etudiant);
        }

        private void CB_EntrepriseStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DOIT REFRESH QUAND UN STAGE EST AJOUTER, SUPPRIMER OU MODIFIER

            Procedure.listeStageByEntreprises(Connection.sqlconnect, CB_EntrepriseStage.Text, DGV_ListeStage);
        }

        void reloadStageCB()
        {
            //RESET COMBOX DATA
            CB_StageNewDes.Items.Clear();
            CB_StageSupprimer.Items.Clear();

            fillCBStages(CB_StageNewDes);
            fillCBStages(CB_StageSupprimer);

            //REFRESH LIST ETUDIANT WITH STAGE
            Procedure.getEtudiantWithStage(Connection.sqlconnect, DGV_Etudiant);

            //REFRESH LISTE STAGE PAR ENTREPRISE IF IS INIT
            if (!CB_EntrepriseStage.Text.Equals(""))
                Procedure.listeStageByEntreprises(Connection.sqlconnect, CB_EntrepriseStage.Text, DGV_ListeStage);
            //RESET NUMBER OF STAGE PER ENERPRISE IF INIT
            if(!LBL_NbStageByEnt.Text.Equals("") && !comboBox1.Text.Equals(""))
                LBL_NbStageByEnt.Text = Procedure.getNbStagesByEntreprise(Connection.sqlconnect, (comboBox1.SelectedItem as ItemsCB).getId()).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    
}
