Select * From Produkt AS P  INNER JOIN  PozycjaZamowienia AS PZ ON P.idProduktu=PZ.idProduktu WHERE IdZamowienia=0 ;
 