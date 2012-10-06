/* Name: Jackson Powell
 * Date: 4/26/12
 * Program: Banking Application
 * Info: Users can create an account, log in, edit their contact info,
 * deposit/withdrawal from a checking and savings account, transfer funds
 * between each account.  An administrator can log in and view contact info
 * but not do anything with the actual accounts.  They're able to edit the
 * contact info and completely delete each user's information and accounts.
 * I prefer to use the List<> class for most of my storage needs.
 */ 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NEW_BANKING_FINAL
{
    public partial class frmBanking : Form
    {
        StreamReader inFile;
        StreamWriter outFile;        
        List<Login> myList = new List<Login>();        
        List<Customer> myCustomers = new List<Customer>();
        Customer myCustomer;
        List<Account> myAccounts = new List<Account>();
        List<Account> myTempAccounts = new List<Account>();
        Account myAccount;
        Login myUser;
        int myUserInt = 0;
        int userIDInt, userAccountInt, myChecking, mySavings;
        string[] login = new string[2];
        string myString;

        public frmBanking()
        {
            ReadUserInfo();
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.TextLength > 0 && txtPassword.TextLength > 0)
            {
                int myInt = 0;
                for (int i = 0; i < myList.Count; i++)
                {
                    if (txtUser.Text == myList[i].UserName)
                    {
                        if (txtPassword.Text == myList[i].Password)
                        {
                            myUserInt = 1;
                            myCustomer = myCustomers[i];
                            SwitchScreen();
                            myInt++;
                            break;
                        }

                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                            myInt++;
                            break;
                        }
                    }
                    myUserInt++;
                }
                if (myInt == 0)
                {
                    MessageBox.Show("Invalid username or password.");
                }
                myInt = 0;
            }
            else
            {
                MessageBox.Show("Make sure you've entered a username and password.");
            }            
        }
        
        /* Reads in user info from a text file detailing username, password,
         * name, id, address, phone, email. */
        private void ReadUserInfo()
        {
            if(myList.Count != 0)
            {
                myList.Clear();
            }
            string line;
            string[] lineArray;
            inFile = new StreamReader("userInfo.txt");
            while (!inFile.EndOfStream)
            {
                line = inFile.ReadLine();
                lineArray = line.Split('|');
                myUser = new Login(lineArray[0], lineArray[1]);
                myList.Add(myUser);
                myCustomer = new Customer(lineArray[0], lineArray[1], int.Parse(lineArray[2]), 
                                          lineArray[3], lineArray[4], lineArray[5], lineArray[6]);
                myCustomers.Add(myCustomer);
                userIDInt = int.Parse(lineArray[2]) + 1;
            }
            inFile.Close();            
            inFile = new StreamReader("accounts.txt");
            while (!inFile.EndOfStream)
            {
                line = inFile.ReadLine();
                lineArray = line.Split(',');
                myAccount = new Account(int.Parse(lineArray[0]), int.Parse(lineArray[1]), 
                                        int.Parse(lineArray[2]), lineArray[3], decimal.Parse(lineArray[4]),
                                        decimal.Parse(lineArray[5]));
                myAccounts.Add(myAccount);
                userAccountInt = int.Parse(lineArray[1]) + 1;
            }            
            inFile.Close();
        }

        //Used every time the users wants to switch a screen.
        private void SwitchScreen()
        {
            switch (myUserInt)
            {
                case 0:
                    grpbxCustomer.Visible = false;
                    grpbxAccounts.Visible = false;
                    grpbxDepWithAccount.Visible = false;
                    grpbxAdminLogin.Visible = false;
                    grpbxAdmin.Visible = false;
                    grpbxAdminCustomer.Visible = false;
                    grpbxCreate.Visible = false;
                    grpbxTransfer.Visible = false;
                    grpbxAdminDelete.Visible = false;
                    grpbxLogin.Visible = true;
                    txtID.Focus();
                    break;
                case 1:
                    grpbxLogin.Visible = false;
                    grpbxAccounts.Visible = false;
                    grpbxDepWithAccount.Visible = false;
                    grpbxAdmin.Visible = false;
                    grpbxAdminCustomer.Visible = false;
                    grpbxAdminLogin.Visible = false;
                    grpbxCreate.Visible = false;
                    grpbxTransfer.Visible = false;
                    grpbxAdminDelete.Visible = false;
                    grpbxCustomer.Visible = true;
                    CustomerOut();
                    break;
                case 2:
                    grpbxLogin.Visible = false;
                    grpbxCustomer.Visible = false;
                    grpbxDepWithAccount.Visible = false;
                    grpbxAdmin.Visible = false;
                    grpbxAdminCustomer.Visible = false;
                    grpbxAdminLogin.Visible = false;
                    grpbxCreate.Visible = false;
                    grpbxTransfer.Visible = false;
                    grpbxAdminDelete.Visible = false;
                    grpbxAccounts.Visible = true;
                    break;
                case 3:
                    grpbxLogin.Visible = false;
                    grpbxCustomer.Visible = false;
                    grpbxAccounts.Visible = false;
                    grpbxAdmin.Visible = false;
                    grpbxAdminCustomer.Visible = false;
                    grpbxAdminLogin.Visible = false;
                    grpbxCreate.Visible = false;
                    grpbxTransfer.Visible = false;
                    grpbxAdminDelete.Visible = false;
                    grpbxDepWithAccount.Visible = true;
                    break;
                case 4:
                    grpbxLogin.Visible = false;
                    grpbxCustomer.Visible = false;
                    grpbxAccounts.Visible = false;
                    grpbxDepWithAccount.Visible = false;
                    grpbxAdmin.Visible = false;
                    grpbxAdminCustomer.Visible = false;
                    grpbxCreate.Visible = false;
                    grpbxTransfer.Visible = false;
                    grpbxAdminDelete.Visible = false;
                    grpbxAdminLogin.Visible = true;
                    break;
                case 5:
                    grpbxLogin.Visible = false;
                    grpbxCustomer.Visible = false;
                    grpbxAccounts.Visible = false;
                    grpbxDepWithAccount.Visible = false;
                    grpbxAdminLogin.Visible = false;
                    grpbxAdminCustomer.Visible = false;
                    grpbxCreate.Visible = false;
                    grpbxTransfer.Visible = false;
                    grpbxAdminDelete.Visible = false;
                    grpbxAdmin.Visible = true;
                    break;
                case 6:
                    grpbxLogin.Visible = false;
                    grpbxCustomer.Visible = false;
                    grpbxAccounts.Visible = false;
                    grpbxDepWithAccount.Visible = false;
                    grpbxAdminLogin.Visible = false;
                    grpbxAdmin.Visible = false;
                    grpbxCreate.Visible = false;
                    grpbxTransfer.Visible = false;
                    grpbxAdminDelete.Visible = false;
                    grpbxAdminCustomer.Visible = true;
                    break;
                case 7:
                    grpbxLogin.Visible = false;
                    grpbxCustomer.Visible = false;
                    grpbxAccounts.Visible = false;
                    grpbxDepWithAccount.Visible = false;
                    grpbxAdminLogin.Visible = false;
                    grpbxAdmin.Visible = false;
                    grpbxAdminCustomer.Visible = false;
                    grpbxCreate.Visible = false;
                    grpbxAdminDelete.Visible = false;
                    grpbxTransfer.Visible = true;
                    break;
                case 8:
                    grpbxLogin.Visible = false;
                    grpbxCustomer.Visible = false;
                    grpbxAccounts.Visible = false;
                    grpbxDepWithAccount.Visible = false;
                    grpbxAdminLogin.Visible = false;
                    grpbxAdmin.Visible = false;
                    grpbxAdminCustomer.Visible = false;
                    grpbxTransfer.Visible = false;
                    grpbxAdminDelete.Visible = false;
                    grpbxCreate.Visible = true;
                    txtCreateName.Focus();
                    break;
                case 9:
                    grpbxLogin.Visible = false;
                    grpbxCustomer.Visible = false;
                    grpbxAccounts.Visible = false;
                    grpbxDepWithAccount.Visible = false;
                    grpbxAdminLogin.Visible = false;
                    grpbxAdmin.Visible = false;
                    grpbxAdminCustomer.Visible = false;
                    grpbxTransfer.Visible = false;
                    grpbxCreate.Visible = false;
                    grpbxAdminDelete.Visible = true;
                    break;
            }           
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {           
            btnApply.Visible = true;
            btnEditInfo.Visible = false;
            btnViewAccount.Visible = false;
            txtName.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtEmail.ReadOnly = false;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            myCustomer.Name = txtName.Text;
            myCustomer.Address = txtAddress.Text;
            myCustomer.Phone = txtPhone.Text;
            myCustomer.Email = txtEmail.Text;
            btnApply.Visible = false;
            btnEditInfo.Visible = true;
            btnViewAccount.Visible = true;
            txtName.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtEmail.ReadOnly = true;
            WriteUserInfo();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            grpbxCustomer.Visible = false;
            grpbxLogin.Visible = true;
            txtUser.Text = "";
            txtPassword.Text = "";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            myUserInt = 8;
            SwitchScreen();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            myUserInt = 4;
            SwitchScreen();
            txtAdminLogin.Focus();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("J&J Banking is a relatively small family owned and operated" +
            "bank located in Lafayette, Indiana.","About Us");
        }

        private void CustomerOut()
        {
            txtID.Text = myCustomer.ID.ToString();
            txtName.Text = myCustomer.Name.ToString();
            txtAddress.Text = myCustomer.Address.ToString();
            txtPhone.Text = myCustomer.Phone.ToString();
            txtEmail.Text = myCustomer.Email.ToString();
        }       

        //Rewrites the users into the userInfo.txt file.
        private void WriteUserInfo()
        {
            outFile = new StreamWriter("userInfo.txt");
            foreach (Customer c in myCustomers)
            {
                outFile.WriteLine(c.ToString());
            }
            outFile.Close();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            myUserInt = 3;
            SwitchScreen();
            txtAmount.Focus();
        }

        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < myAccounts.Count; i++)
                {
                    if (myAccounts[i].UserId == myCustomer.ID && myAccounts[i].Type == 0)
                    {
                        txtChecking.Text = myAccounts[i].Balance.ToString("C");
                        myChecking = i;
                    }
                    if (myAccounts[i].UserId == myCustomer.ID && myAccounts[i].Type == 1)
                    {
                        txtSavings.Text = myAccounts[i].Balance.ToString("C");
                        txtInterest.Text = (myAccounts[i].Interest * 100).ToString("N2") + '%';
                        mySavings = i;
                    }
                }
                myUserInt = 2;
                SwitchScreen();
            }
            catch
            {
                MessageBox.Show("There was an issue with viewing this account.  Please try again later.",
                                "ERROR!");
            }
        }

        private void btnBackAccount_Click(object sender, EventArgs e)
        {
            myUserInt = 1;
            SwitchScreen();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            myUserInt = 2;
            SwitchScreen();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnDeposit.Checked == true && rbtnDepWithChecking.Checked == true)
                {                    
                    myAccounts[myChecking].Deposit(decimal.Parse(txtAmount.Text));  
                    txtChecking.Text = myAccounts[myChecking].Balance.ToString("C");
                    myString = "Successfully deposited $" + txtAmount.Text + " to your " +
                        " checking account.";
                }
                else if (rbtnDeposit.Checked == true && rbtnDepWithSavings.Checked == true)
                {
                    myAccounts[mySavings].Deposit(decimal.Parse(txtAmount.Text));
                    txtSavings.Text = myAccounts[mySavings].Balance.ToString("C");
                    myString = "Successfully deposited $" + txtAmount.Text + " to your " +
                        " savings account.";
                }
                else if (rbtnWithdrawal.Checked == true && rbtnDepWithChecking.Checked == true)
                {
                    if (myAccounts[myChecking].Balance >= decimal.Parse(txtAmount.Text))
                    {
                        myAccounts[myChecking].Withdrawal(decimal.Parse(txtAmount.Text));
                        txtChecking.Text = myAccounts[myChecking].Balance.ToString("C");
                        myString = "Successfully withdrawn $" + txtAmount.Text + " from your " +
                            " checking account.";
                    }
                    else
                    {
                        myString = "Insufficient funds to complete this transaction.";
                    }
                }
                else if (rbtnWithdrawal.Checked == true && rbtnDepWithSavings.Checked == true)
                {
                    if(myAccounts[mySavings].Balance >= decimal.Parse(txtAmount.Text))
                    {
                    myAccounts[mySavings].Withdrawal(decimal.Parse(txtAmount.Text));
                    txtSavings.Text = myAccounts[mySavings].Balance.ToString("C");
                    myString = "Successfully withdrawn $" + txtAmount.Text + " from your " +
                        " savings account.";
                    }
                    else
                    {
                        myString = "Insufficient funds to complete this transaction.";
                    }
                }                
                myUserInt = 2;
                SwitchScreen();
                MessageBox.Show(myString, "Transaction Information");
                WriteAccounts();
                txtAmount.Text = "";                      
            }
            catch
            {
                MessageBox.Show("Make sure you've entered a valid amount, " +
                                "an action, and an account.", "ERROR!");
            }
        }

        private void WriteAccounts()
        {
            try
            {
                outFile = new StreamWriter("accounts.txt");
                foreach (Account a in myAccounts)
                {
                    outFile.WriteLine(a.ToString());
                }
                outFile.Close();
            }
            catch
            {
                MessageBox.Show("There was an error in writing the accounts to \"accounts.txt\".", "ERROR!");
            }
        }

        private void btnAdminLogout_Click(object sender, EventArgs e)
        {
            myUserInt = 0;
            SwitchScreen();
        }

        private void btnAdminEdit_Click(object sender, EventArgs e)
        {
            try
            {                
                myCustomer = myCustomers[lstbxUsers.SelectedIndex];
                AdminCustomerOut();
                myUserInt = 6;
                SwitchScreen();
                lstbxUsers.SelectedIndex = -1;             
            }
            catch
            {
                MessageBox.Show("Make sure you've selected a customer.", "ERROR!");
            }
        }       

        private void txtAdminLogin_TextChanged(object sender, EventArgs e)
        {
            if(txtAdminLogin.Text == "0134558")
            {
                
                myUserInt = 5;
                /*lstbxUsers.Items.Clear();
                  foreach (Customer c in myCustomers)
                {
                    lstbxUsers.Items.Add(c.Name.ToString());
                }*/
                AdminPopulate();
                SwitchScreen();
                txtAdminLogin.Text = "";
            }
        }

        private void btnAdminCancel_Click(object sender, EventArgs e)
        {
            myUserInt = 0;
            SwitchScreen();
        }
        
        private void AdminCustomerOut()
        {
            txtAdminCustomerID.Text = myCustomer.ID.ToString();
            txtAdminCustomerName.Text = myCustomer.Name.ToString();
            txtAdminCustomerAddress.Text = myCustomer.Address.ToString();
            txtAdminCustomerPhone.Text = myCustomer.Phone.ToString();
            txtAdminCustomerEmail.Text = myCustomer.Email.ToString();
        }

        private void btnAdminCustomerApply_Click_1(object sender, EventArgs e)
        {
            try
            {
                myCustomer.Name = txtAdminCustomerName.Text;
                myCustomer.Address = txtAdminCustomerAddress.Text;
                myCustomer.Phone = txtAdminCustomerPhone.Text;
                myCustomer.Email = txtAdminCustomerEmail.Text;
                WriteUserInfo();
                MessageBox.Show("Customer information has been updated.", "SUCCESS!");
            }
            catch
            {
                MessageBox.Show("The update process could not be completed.", "ERROR!");
            }
        }

        private void btnAdminCustomerBack_Click(object sender, EventArgs e)
        {
            /*lstbxUsers.Items.Clear();
            foreach (Customer c in myCustomers)
            {
                lstbxUsers.Items.Add(c.Name.ToString());
            }*/
            AdminPopulate();
            myUserInt = 5;
            SwitchScreen();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                string[] line;
                string myDate;
                if (txtCreateName.Text.Count() > 0 && txtCreateAddress.Text.Count() > 0 && txtCreatePhone.Text.Count() > 0 && 
                    txtCreateEmail.Text.Count() > 0 && txtCreatePassword.Text.Count() > 0)
                {
                    myDate = DateTime.Today.ToString();
                    line = myDate.Split(' ');
                    myCustomer = new Customer(txtCreateUsername.Text,txtCreatePassword.Text, userIDInt,
                        txtCreateName.Text, txtCreateAddress.Text, txtCreatePhone.Text, txtCreateEmail.Text);
                    myCustomers.Add(myCustomer);
                    myUser = new Login(myCustomer.UserName, myCustomer.UserPassword);
                    myList.Add(myUser);
                    StreamWriter newUser = File.AppendText("userInfo.txt");
                    newUser.WriteLine(myCustomer.ToString());                    
                    myUserInt = 0;
                    newUser.Close();
                    for(int i = 0;i < 2; i++)
                    {
                        if (i == 0)
                        {
                            myAccount = new Account(userIDInt, userAccountInt, i, line[0], 0, 0);
                            myAccounts.Add(myAccount);
                            userAccountInt++;
                        }
                        else
                        {
                            myAccount = new Account(userIDInt, userAccountInt, i, line[0], 0, .0125m);
                            myAccounts.Add(myAccount);
                            userAccountInt++;
                            userIDInt++;
                        }
                    }
                }
                WriteUserInfo();
                WriteAccounts();
                SwitchScreen();
            }
            catch
            {
                MessageBox.Show("There was an error with creating this account.  Please try again later.", "ERROR!");
            }
        }

        private void btnCreateBack_Click(object sender, EventArgs e)
        {
            myUserInt = 0;
            SwitchScreen();
        }

        private void btnTransferConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                decimal myDec = decimal.Parse(txtTransferAmount.Text);
                string[] myOut = {"",""};
                if (rbtnTransferFromChecking.Checked == true && rbtnTransferToChecking.Checked == true)
                {
                    MessageBox.Show("You cannot transfer to and from the same account.");
                }
                else if (rbtnTransferFromSavings.Checked == true && rbtnTransferToSavings.Checked == true)
                {
                    MessageBox.Show("You cannot transfer to and from the same account.");
                }
                else if (rbtnTransferFromChecking.Checked == true && rbtnTransferToSavings.Checked == true)
                {
                    if (myAccounts[myChecking].Balance >= myDec)
                    {
                        myAccounts[myChecking].Balance -= myDec;
                        myAccounts[mySavings].Balance += myDec;
                        myOut[0] = "Transfer successfully completed";
                        myOut[1] = "Success";
                    }
                    else
                    {
                        myOut[0] = "Your savings account lacks the funds to complete this transfer.";
                        myOut[1] = "Insufficient Funds";
                    }
                    myUserInt = 2;
                }
                else if (rbtnTransferFromSavings.Checked == true && rbtnTransferToChecking.Checked == true)
                {
                    if (myAccounts[mySavings].Balance >= myDec)
                    {
                        myAccounts[myChecking].Balance += myDec;
                        myAccounts[mySavings].Balance -= myDec;
                        myOut[0] = "Transfer successfully completed";
                        myOut[1] = "Success";
                    }
                    else
                    {
                        myOut[0] = "Your savings account lacks the funds to complete this transfer.";
                        myOut[1] = "Insufficient Funds";
                    }
                    myUserInt = 2;
                }
                else
                {
                    myOut[0] = "Invalid selections.";
                    myOut[1] = "ERROR!";
                }
                WriteAccounts();
                txtChecking.Text = myAccounts[myChecking].Balance.ToString("C");
                txtSavings.Text = myAccounts[mySavings].Balance.ToString("C");
                SwitchScreen();
                MessageBox.Show(myOut[0], myOut[1]);
            }
            catch
            {
                MessageBox.Show("This transfer could not be completed.", "ERROR!");
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            myUserInt = 7;
            SwitchScreen();
        }

        private void btnTransferBack_Click(object sender, EventArgs e)
        {
            myUserInt = 2;
            SwitchScreen();
        }

        private void btnAdminDelete_Click(object sender, EventArgs e)
        {
            myUserInt = 9;
            SwitchScreen();
            txtAdminConfirm.Focus();
        }

        private void btnAdminConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                myUserInt = 5;
                SwitchScreen();
                if (txtAdminConfirm.Text == "confirm")
                {
                    string line;
                    string[] lineArray;
                    int myAdminInt = 0;
                    int myAdminComparison = 0;
                    line = myCustomers[lstbxUsers.SelectedIndex].ToString();
                    lineArray = line.Split('|');
                    myAdminInt = int.Parse(lineArray[2]);
                    while (myAdminComparison < myCustomers.Count())
                    {
                        if (myCustomers[myAdminComparison].ID.ToString() == lineArray[2])
                        {
                            myCustomers.RemoveAt(myAdminComparison);
                            myAdminComparison--;
                        }
                        myAdminComparison++;
                    }
                    myAdminComparison = 0;
                    while (myAdminComparison < myAccounts.Count())
                    {
                        if (myAccounts[myAdminComparison].UserId.ToString() == lineArray[2])
                        {
                            myAccounts.RemoveAt(myAdminComparison);
                            myAdminComparison--;
                        }
                        myAdminComparison++;
                    }
                }
                else
                {
                    MessageBox.Show("You did not correctly type the confirmation.", "Unsuccessful");
                }
                txtAdminConfirm.Clear();
                WriteUserInfo();
                WriteAccounts();
                AdminPopulate();
            }
            catch
            {
                MessageBox.Show("Could not delete user.", "ERROR!");
            }
        }
        private void AdminPopulate()
        {
            lstbxUsers.Items.Clear();
            foreach (Customer c in myCustomers)
            {
                lstbxUsers.Items.Add(c.Name.ToString());
            }
        }

        private void btnAdminConfirmBack_Click(object sender, EventArgs e)
        {
            myUserInt = 5;
            SwitchScreen();
            txtAdminConfirm.Clear();
        }         
    }
}
