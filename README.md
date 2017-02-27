# FA53_Schifffahrtsquiz

Ein Quiz ueber Schifffahrt.

//**Database Setup**    
     
MySQL Statement available on Moodle-Server. Execute in MySQL database to create fully operational tables.    
    
Tables needed:
* t_fragebogen_unter_maschine    
* t_sbf_binnen     
* *//Table "Funker"*
        
setup Visual Studio for MySQL usage:

* 1. Download .dll    
  [https://dev.mysql.com/downloads/file/?id=463758](https://dev.mysql.com/downloads/file/?id=463758)
* 2. Download installer for Visual Studio (installing takes a while)    
  [https://dev.mysql.com/downloads/windows/visualstudio/](https://dev.mysql.com/downloads/windows/visualstudio/)    
* 3. in VS add references:    
  `MySQL.Data, MySQL.Data.Entity`    

tablename: binnenschifffahrt    
user: FA53_osz    
pwd: osz    

//**Open Questions**    
     
* Is there a MySQL query available for the "Binnenschifffahrt Funk V1.0 - SQL Script"?    
* What should we do with the pictures?
