<<<<<<< HEAD
function suppliesForSchool(input){
    let packetOfChemicalsCNT = Number(input[0]);
    let packetOfMarkersCnt = Number(input[1]);
    let litresOfBoardCleaner = Number([input[2]]);
    let discount = Number(input[3]);

    let packetChemicalsPrice = 5.80;
    let packerOfMarkersPrice = 7.20;
    let boardCleanerPriceForOneLiter = 1.20;

    let chemicalsPrice = packetOfChemicalsCNT * packetChemicalsPrice;
    let markersPrice = packetOfMarkersCnt * packerOfMarkersPrice;
    let boardCleanerPrice = litresOfBoardCleaner * boardCleanerPriceForOneLiter;

    let finalSum = chemicalsPrice + markersPrice + boardCleanerPrice;
    let finalPriceWithDiscount = finalSum - (finalSum * (discount / 100));

    console.log(finalPriceWithDiscount);
}

suppliesForSchool(["2", "3", "4", "25"]);
=======
function suppliesForSchool(input){
    let packetOfChemicalsCNT = Number(input[0]);
    let packetOfMarkersCnt = Number(input[1]);
    let litresOfBoardCleaner = Number([input[2]]);
    let discount = Number(input[3]);

    let packetChemicalsPrice = 5.80;
    let packerOfMarkersPrice = 7.20;
    let boardCleanerPriceForOneLiter = 1.20;

    let chemicalsPrice = packetOfChemicalsCNT * packetChemicalsPrice;
    let markersPrice = packetOfMarkersCnt * packerOfMarkersPrice;
    let boardCleanerPrice = litresOfBoardCleaner * boardCleanerPriceForOneLiter;

    let finalSum = chemicalsPrice + markersPrice + boardCleanerPrice;
    let finalPriceWithDiscount = finalSum - (finalSum * (discount / 100));

    console.log(finalPriceWithDiscount);
}

suppliesForSchool(["2", "3", "4", "25"]);
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
suppliesForSchool(["4", "2", "5", "13"]);