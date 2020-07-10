﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
/*PROPERTY OF KLC_BY AVILILLA*/
namespace VORP_BankServer
{
    public class Bank:BaseScript
    {

        private Dictionary<string,BankUser> bankUsers = new Dictionary<string, BankUser>();
        private string _name;
        private double _money;
        private double _gold;
      
        public Bank(string name, double money, double gold)
        {
            this._name = name;
            this._money = money;
            this._gold = gold;
        }

        public void ShowUsers(){
            foreach(KeyValuePair<string,BankUser> user in bankUsers){
                Debug.WriteLine(user.Key);
            }
        }

        public void AddUser(BankUser user)
        {
            if (!this.bankUsers.ContainsKey(user.Identifier))
            {
                this.bankUsers.Add(user.Identifier, user);
            }
        }

        public void AddNewUser(string identifier)
        {
            BankUser user = new BankUser(identifier,0.0,0.0);
            if (!this.bankUsers.ContainsKey(user.Identifier))
            {
                this.bankUsers.Add(identifier,user);
            }
        }

        public BankUser GetUser(string identifier){
            if(bankUsers.ContainsKey(identifier)){
                return bankUsers[identifier];
            }else{
                return null;
            }
        }

        public bool UserExist(string identifier){
            return bankUsers.ContainsKey(identifier);
        }

        public bool AddUserMoney(string identifier,double money){
            if(bankUsers.ContainsKey(identifier)){
                double newMoney = bankUsers[identifier].GetMoney()+money;
                bankUsers[identifier].SetMoney(newMoney);
                this._money+= money;
                return true;
            }else{
                bankUsers.Add(identifier,new BankUser(identifier,0,money));
                return true;
            }
        }

        public bool SubUserMoney(string identifier,double money){
            if(bankUsers.ContainsKey(identifier)){
                double nowMoney = bankUsers[identifier].GetMoney();
                if(nowMoney-money < 0.0){
                    return false;
                }else{
                    bankUsers[identifier].SetMoney(nowMoney-money);
                    this._money-= money;
                    return true;
                }
            }else{
                return false;
            }
        }

        public bool AddUserGold(string identifier,double gold){
            if(bankUsers.ContainsKey(identifier)){
                double newGold = bankUsers[identifier].GetGold()+gold;
                bankUsers[identifier].SetMoney(newGold);
                this._gold+= gold;
                return true;
            }else{
                bankUsers.Add(identifier,new BankUser(identifier,gold,0));
                return true;
            }
        }

        public bool SubUserGold(string identifier,double gold){
            if(bankUsers.ContainsKey(identifier)){
                double nowGold = bankUsers[identifier].GetGold();
                if(nowGold-gold < 0.0){
                    return false;
                }else{
                    bankUsers[identifier].SetMoney(nowGold-gold);
                    this._gold-= gold;
                    return true;
                }
            }else{
                return false;
            }
        }

        public string GetName()
        {
            return this._name;
        }

        public void SetName(string name)
        {
            this._name = name;
        }

        public double GetMoney()
        {
            return this._money;
        }

        public void SetMoney(double money)
        {
            this._money = money;
        }

        public double GetGold()
        {
            return this._gold;
        }

        public void SetGold(double gold)
        {
            this._gold = gold;
        }
    }
}
