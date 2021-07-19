/* 
    Operazione 1 - Inserire un assicurato
*/
BEGIN TRANSACTION;
    DECLARE @Assicurato INT
    SET @Assicurato = (SELECT TOP 1 ID_Assicurato
                    FROM Assicurati
                    ORDER BY ID_Assicurato DESC) + 1;
    INSERT INTO Assicurati (Nome, Cognome, DataNascita, CodiceFiscale, Telefono, Email) 
    VALUES (?, ?, ?, ?, ?, ?);
    INSERT INTO Polizze (Tipo, Assicurato, Assicurazione, Massimale, Costo, Scadenza) 
    VALUES (?, @Assicurato, ?, ?, ?, ?);
COMMIT;

/*
    Operazione 2 - Visualizzare tutte le polizze di un assicurato
*/
SELECT *
FROM Polizze
WHERE Assicurato = ?;

/*
    Operazione 3 - Stipulazione di una nuova polizza tra assicurato e  assicurazione
*/
INSERT INTO Polizze (Tipo, Assicurato, Assicurazione, Massimale, Costo, Scadenza) 
VALUES (?, ?, ?, ?, ?, ?);

/*
    Operazione 4 - Registrare un nuovo studio peritale 
*/
BEGIN TRANSACTION;
    DECLARE @Luogo INT
    SET @Luogo = (SELECT TOP 1 ID_Luogo
                    FROM Luoghi
                    ORDER BY ID_Luogo DESC) + 1;
    INSERT INTO Luoghi (Provincia, Via, NumeroCivico, CAP, Comune, Citta)
    VALUES (?, ?, ?, ?, ?, ?);
    INSERT INTO Studi_Peritali (Luogo, Nome, Telefono, Email) 
    VALUES (@Luogo, ?, ?, ?);
    INSERT INTO Supervisori (Nome, Cognome, DataNascita, CodiceFiscale, Telefono, Email) 
    VALUES (?, ?, ?, ?, ?, ?);
    INSERT INTO Periti (Nome, Cognome, DataNascita, CodiceFiscale, Telefono, Email) 
    VALUES (?, ?, ?, ?, ?, ?);
COMMIT;
/* Le chiavi primarie vengono impostate e incrementate automaticamente */

/*
    Operazione 5 - Rimuovere uno studio peritale 
*/
DELETE FROM Studi_Peritali WHERE ?;

/*
    Operazione 6 - Generare un sinistro e delegarlo a uno studio peritale
*/
INSERT INTO Sinistri (Assicurazione, Descrizione, Data, Categoria, Luogo, Studio_Peritale, Assicurato)
VALUES (?, ?, ?, ?, ?, ?, ?)

/*
    Operazione 7 - Assumere un supervisore in uno studio
*/
INSERT INTO Supervisori (Nome, Cognome, DataNascita, CodiceFiscale, Telefono, Email) 
VALUES (?, ?, ?, ?, ?, ?);

/*
    Operazione 8 - Licenziare il perito di uno studio 
*/
DELETE FROM Perito
WHERE ?;

/*
    Operazione 9 - Il  supervisore  crea  un  nuovo  incarico  e  lo  assegna  a  un perito 
*/
INSERT INTO Incarichi (Perito, Supervisore, ID_Sinistro, Stato)
VALUES (?, ?, ?, ?);

/*
    Operazione 10 - Leggere tutti gli incarichi aperti in un determinato studio
*/
SELECT *
FROM Incarichi
WHERE Stato == "Aperto" AND ID_Studio = ?;

/*
    Operazione 11 - Visualizzare quale assicurato ha svolto una determinata video-perizia 
*/
SELECT ID_Assicurato
FROM Video_Perizie
WHERE ?;

/*
    Operazione 12 - Aggiungere un documento ad un incarico 
*/
INSERT INTO Documenti (ID_Incarico, Incarico, Tipo)
VALUES (?, ?, ?);

/*
    Operazione 13 - Inserire una video-perizia per un incarico 
*/
INSERT INTO Video_Perizie (Incarico, Durata)
VALUES (?, ?);

/*
    Operazione 14 - Visualizzare il proprietario (assicurato) di un documento
*/
SELECT ID_Assicurato
FROM Documenti
WHERE ?;

/*
    Operazione 15 - Visualizzare in media quanto durano le video-perizie di un determinato studio peritale 
*/
SELECT AVG(Durata) AS DurataMedia
FROM Video_Perizie AS Perizie
INNER JOIN Incarichi 
ON Perizie.Incarico = Incarichi.ID_Incarico
INNER JOIN Supervisori
ON Incarichi.Supervisore = Supervisori.ID_Supervisore
INNER JOIN Studi_Peritali 
ON Supervisori.Studio = Studi_Peritali.ID_Studio
WHERE Studio = ?;

/*
    Operazione 16 - Qual e' la provincia nella quale avvengono piu' sinistri
*/
SELECT TOP 1 Provincia, COUNT(*) as TotaleIncarichi
FROM Sinistri 
INNER JOIN Luoghi
ON Sinistri.ID_Luogo = Luoghi.ID_Luogo
GROUP BY Provincia
ORDER BY TotaleIncarichi DESC