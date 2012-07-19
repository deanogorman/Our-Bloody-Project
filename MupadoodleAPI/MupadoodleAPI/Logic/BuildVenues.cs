using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MupadoodleAPI.Models;
using MupadoodleAPI.DataAccess;
using MupadoodleAPI.Ingestion;

namespace MupadoodleAPI.Logic
{
    public class BuildVenues
    {
        private CSVReader csvr = new CSVReader();

        public BuildVenues()
        {
            addMusuemsFiletoDB();
            // Add all the other files to the db
            // we should really rename this method addVenuesFilestoDB
            addParksFiletoDB();
        }

        private void addMusuemsFiletoDB()
        {
            List<Museum> mList = csvr.getCSVFileDataMuseums();
            MuseumDAL mDAL = new MuseumDAL();

            // Get all the Parks already in the dB and compare to this list
            // Add any in this list that aren't in the dB
            // Update any in this list that are already in the dB

            List<Museum> dbmList = mDAL.getAllMuseumsFromDb();

            bool result = false, notIndB = true;

            // stick it in the dB
            foreach (Museum m in mList)
            {
                foreach (Museum dbm in dbmList)
                {
                    if (dbm.lname.Equals(m.lname))
                    {
                        notIndB = false;
                        break;
                    }
                }
                if (notIndB)
                {
                    // Add to the dB

                    // we could bother to check the result
                    result = mDAL.addMuseumToDb(m);
                }
                else
                {
                    // Update the record in the dB (assuming structure the same)
                    // I think we change every field in the dbm that could have changed
                    // and then call mDAL.updateMuseumInDb(dbm)
                }
            }
        }

        private void addParksFiletoDB()
        {
            List<Park> pList = csvr.getCSVFileDataParks();
            ParkDAL pDAL = new ParkDAL();

            // Get all the Parks already in the dB and compare to this list
            // Add any in this list that aren't in the dB
            // Update any in this list that are already in the dB

            List<Park> dbpList = pDAL.getAllParksFromDb();

            bool result = false, notIndB = true;

            // stick it in the dB
            foreach (Park p in pList)
            {
                foreach (Park dbp in dbpList)
                {
                    if (dbp.lname.Equals(p.lname))
                    {
                        notIndB = false;
                        break;
                    }
                }
                if (notIndB)
                {
                    // Add to the dB

                    // we could bother to check the result
                    result = pDAL.addParkToDb(p);
                }
                else
                {
                    // Update the record in the dB (assuming structure the same)
                    // I think we change every field in the dbp that could have changed
                    // and then call pDAL.updateParkInDb(dbp)
                }
            }
        }
    }
}