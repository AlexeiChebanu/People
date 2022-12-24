﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace ServiceContracts
{
    public interface IPersonService
    {
        /// <summary>
        /// Adds a new person into the list of persons
        /// </summary>
        /// <param name="personAddRequest"></param>
        /// <returns></returns>
        PersonResponse AddPerson(PersonAddRequest? personAddRequest);
        /// <summary>
        /// Returns all presons
        /// </summary>
        /// <returns></returns>
        List<PersonResponse> GetAllPersons();
        /// <summary>
        /// Returns the person obj based on the given person id
        /// </summary>
        /// <param name="personID">Person id to search</param>
        /// <returns>Matching person obj</returns>
        PersonResponse? GetPersonByPersonID(Guid? personID);

        /// <summary>
        /// Returns all person obj that matches with thr given search field and search string
        /// </summary>
        /// <param name="searchBy">Search field to search </param>
        /// <param name="searchString">Search string to search</param>
        /// <returns>returns all matching persons based on the given search and search string</returns>
        List<PersonResponse> GetFilterdPersons(string searchBy, string? searchString);

        /// <summary>
        /// Returns sorted list of persons
        /// </summary>
        /// <param name="allPersons">Represents list of persons to sort</param>
        /// <param name="sortBy">Name of the property(Key), based on which the persons
        /// should be sorted</param>
        /// <param name="sortOrder">Asc or Decs</param>
        /// <returns>Returns sorted persons as PersonResponse List</returns>
        List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder);
    }
}
