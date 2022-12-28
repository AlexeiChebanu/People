﻿using Entities;
using Microsoft.VisualBasic;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly List<Person> _persons;
        private readonly ICountriesService _countriesService;
        public PersonService(/*PersonDbContext personDbContext, ICountriesService countriesService */ bool initialize = true)
        {
            /*_persons = personDbContext; 
            _countriesService= countriesService; */

            _persons = new List<Person>();
            _countriesService = new CountriesService();

            if (initialize)
            {
                _persons.Add(new Person() { PersonID = Guid.Parse("8082ED0C-396D-4162-AD1D-29A13F929824"), PersonName = "Aguste", Email = "aleddy0@booking.com", DateOfBirth = DateTime.Parse("1993-01-02"), Gender = "Male", Address = "0858 Novick Terrace", ReceiveNewsLetters = false, CountryID = Guid.Parse("000C76EB-62E9-4465-96D1-2C41FDB64C3B") });

                _persons.Add(new Person() { PersonID = Guid.Parse("06D15BAD-52F4-498E-B478-ACAD847ABFAA"), PersonName = "Jasmina", Email = "jsyddie1@miibeian.gov.cn", DateOfBirth = DateTime.Parse("1991-06-24"), Gender = "Female", Address = "0742 Fieldstone Lane", ReceiveNewsLetters = true, CountryID = Guid.Parse("32DA506B-3EBA-48A4-BD86-5F93A2E19E3F") });

                _persons.Add(new Person() { PersonID = Guid.Parse("D3EA677A-0F5B-41EA-8FEF-EA2FC41900FD"), PersonName = "Kendall", Email = "khaquard2@arstechnica.com", DateOfBirth = DateTime.Parse("1993-08-13"), Gender = "Male", Address = "7050 Pawling Alley", ReceiveNewsLetters = false, CountryID = Guid.Parse("32DA506B-3EBA-48A4-BD86-5F93A2E19E3F") });

                _persons.Add(new Person() { PersonID = Guid.Parse("89452EDB-BF8C-4283-9BA4-8259FD4A7A76"), PersonName = "Kilian", Email = "kaizikowitz3@joomla.org", DateOfBirth = DateTime.Parse("1991-06-17"), Gender = "Male", Address = "233 Buhler Junction", ReceiveNewsLetters = true, CountryID = Guid.Parse("DF7C89CE-3341-4246-84AE-E01AB7BA476E") });

                _persons.Add(new Person() { PersonID = Guid.Parse("F5BD5979-1DC1-432C-B1F1-DB5BCCB0E56D"), PersonName = "Dulcinea", Email = "dbus4@pbs.org", DateOfBirth = DateTime.Parse("1996-09-02"), Gender = "Female", Address = "56 Sundown Point", ReceiveNewsLetters = false, CountryID = Guid.Parse("DF7C89CE-3341-4246-84AE-E01AB7BA476E") });

                _persons.Add(new Person() { PersonID = Guid.Parse("A795E22D-FAED-42F0-B134-F3B89B8683E5"), PersonName = "Corabelle", Email = "cadams5@t-online.de", DateOfBirth = DateTime.Parse("1993-10-23"), Gender = "Female", Address = "4489 Hazelcrest Place", ReceiveNewsLetters = false, CountryID = Guid.Parse("15889048-AF93-412C-B8F3-22103E943A6D") });

                _persons.Add(new Person() { PersonID = Guid.Parse("3C12D8E8-3C1C-4F57-B6A4-C8CAAC893D7A"), PersonName = "Faydra", Email = "fbischof6@boston.com", DateOfBirth = DateTime.Parse("1996-02-14"), Gender = "Female", Address = "2010 Farragut Pass", ReceiveNewsLetters = true, CountryID = Guid.Parse("80DF255C-EFE7-49E5-A7F9-C35D7C701CAB") });

                _persons.Add(new Person() { PersonID = Guid.Parse("7B75097B-BFF2-459F-8EA8-63742BBD7AFB"), PersonName = "Oby", Email = "oclutheram7@foxnews.com", DateOfBirth = DateTime.Parse("1992-05-31"), Gender = "Male", Address = "2 Fallview Plaza", ReceiveNewsLetters = false, CountryID = Guid.Parse("80DF255C-EFE7-49E5-A7F9-C35D7C701CAB") });

                _persons.Add(new Person() { PersonID = Guid.Parse("6717C42D-16EC-4F15-80D8-4C7413E250CB"), PersonName = "Seumas", Email = "ssimonitto8@biglobe.ne.jp", DateOfBirth = DateTime.Parse("1999-02-02"), Gender = "Male", Address = "76779 Norway Maple Crossing", ReceiveNewsLetters = false, CountryID = Guid.Parse("80DF255C-EFE7-49E5-A7F9-C35D7C701CAB") });

                _persons.Add(new Person() { PersonID = Guid.Parse("6E789C86-C8A6-4F18-821C-2ABDB2E95982"), PersonName = "Freemon", Email = "faugustin9@vimeo.com", DateOfBirth = DateTime.Parse("1996-04-27"), Gender = "Male", Address = "8754 Becker Street", ReceiveNewsLetters = false, CountryID = Guid.Parse("80DF255C-EFE7-49E5-A7F9-C35D7C701CAB") });
            }
        }
        private PersonResponse ConvertPersonToPersonResponse(Person person)
        {
            PersonResponse personResponse = person.ToPersonResponse();
            personResponse.Country = _countriesService.GetCountryByCountryId(person.CountryID)?.CountryName;
            return personResponse;

        }
        public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
        {
            //check if PersonAddRequest is not null
            if (personAddRequest == null)
                throw new ArgumentNullException(nameof(personAddRequest));

            //ModelValidation
            ValidationHelper.ModelValidation(personAddRequest);

            //convert personAddRequest into Person type
            Person person = personAddRequest.ToPerson();

            //generate PersonID
            person.PersonID = Guid.NewGuid();

            _persons./*Persons*/Add(person);
            /*_persons.SaveChanges();*/

            //convert the Person obj into PersonResponse type
            return ConvertPersonToPersonResponse(person);
        }

        public List<PersonResponse> GetAllPersons()
            => _persons./*Persons.ToList().*/Select(n => ConvertPersonToPersonResponse(n)).ToList();


        public PersonResponse? GetPersonByPersonID(Guid? personID)
        {
            if (personID == null)
                return null;

            Person? person = _persons/*.Persons*/.FirstOrDefault(temp => temp.PersonID == personID);
            if (person == null)
                return null;

            return ConvertPersonToPersonResponse(person);
        }

        public List<PersonResponse> GetFilterdPersons(string searchBy, string? searchString)
        {
            List<PersonResponse> allPersons = GetAllPersons();
            List<PersonResponse> matchingPersons = allPersons;

            if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchString))
                return matchingPersons;

            switch (searchBy)
            {
                case nameof(PersonResponse.PersonName):
                    matchingPersons = allPersons.Where(temp =>
                    (!string.IsNullOrEmpty(temp.PersonName) ? temp
                    .PersonName
                    .Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PersonResponse.Email):
                    matchingPersons = allPersons.Where(temp =>
                            (!string.IsNullOrEmpty(temp.Email) ? temp
                            .Email
                            .Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PersonResponse.DateOfBirth):
                    matchingPersons = allPersons.Where(temp =>
                            (temp.DateOfBirth != null) ? temp
                            .DateOfBirth.Value.ToString("dd MMMM yyyy")
                            .Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;

                case nameof(PersonResponse.Gender):
                    matchingPersons = allPersons.Where(temp =>
                            (!string.IsNullOrEmpty(temp.Gender) ? temp
                            .Gender
                            .StartsWith(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PersonResponse.CountryID):
                    matchingPersons = allPersons.Where(temp =>
                            (!string.IsNullOrEmpty(temp.Country) ? temp
                            .Country
                            .Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PersonResponse.Address):
                    matchingPersons = allPersons.Where(temp =>
                            (!string.IsNullOrEmpty(temp.Address) ? temp
                            .Address
                            .Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                default: matchingPersons = allPersons; break;
            }
            return matchingPersons;
        }

        public List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder)
        {
            if (string.IsNullOrEmpty(sortBy))
                return allPersons;

            List<PersonResponse> sortedPersons = (sortBy, sortOrder) switch
            {
                (nameof(PersonResponse.PersonName), SortOrderOptions.Asc) => allPersons.OrderBy(temp => temp.PersonName,
                                                                                StringComparer.OrdinalIgnoreCase)
                                                                                .ToList(),

                (nameof(PersonResponse.PersonName), SortOrderOptions.Desc) => allPersons.OrderByDescending(temp => temp.PersonName,
                                                                                StringComparer.OrdinalIgnoreCase)
                                                                                .ToList(),

                (nameof(PersonResponse.Email), SortOrderOptions.Asc) => allPersons.OrderBy(temp => temp.Email,
                                                                                StringComparer.OrdinalIgnoreCase)
                                                                                .ToList(),

                (nameof(PersonResponse.Email), SortOrderOptions.Desc) => allPersons.OrderByDescending(temp => temp.Email,
                                                                                StringComparer.OrdinalIgnoreCase)
                                                                                .ToList(),

                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.Asc) => allPersons.OrderBy(temp => temp.DateOfBirth)
                                                                                .ToList(),

                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.Desc) => allPersons.OrderByDescending(temp => temp.DateOfBirth)
                                                                                .ToList(),

                (nameof(PersonResponse.Age), SortOrderOptions.Asc) => allPersons.OrderBy(temp => temp.Age)
                                                                                .ToList(),

                (nameof(PersonResponse.Age), SortOrderOptions.Desc) => allPersons.OrderByDescending(temp => temp.Age)
                                                                                .ToList(),

                (nameof(PersonResponse.Gender), SortOrderOptions.Asc) => allPersons.OrderBy(temp => temp.Gender,
                                                                                StringComparer.OrdinalIgnoreCase)
                                                                                .ToList(),

                (nameof(PersonResponse.Gender), SortOrderOptions.Desc) => allPersons.OrderByDescending(temp => temp.Gender,
                                                                                StringComparer.OrdinalIgnoreCase)
                                                                                .ToList(),
                (nameof(PersonResponse.Country), SortOrderOptions.Asc) => allPersons.OrderBy(temp => temp.Country,
                                                                                StringComparer.OrdinalIgnoreCase)
                                                                                .ToList(),

                (nameof(PersonResponse.Country), SortOrderOptions.Desc) => allPersons.OrderByDescending(temp => temp.Country,
                                                                                StringComparer.OrdinalIgnoreCase)
                                                                                .ToList(),

                (nameof(PersonResponse.Address), SortOrderOptions.Asc) => allPersons.OrderBy(temp => temp.Address,
                                                                                StringComparer.OrdinalIgnoreCase)
                                                                                .ToList(),

                (nameof(PersonResponse.Address), SortOrderOptions.Desc) => allPersons.OrderByDescending(temp => temp.Address,
                                                                                StringComparer.OrdinalIgnoreCase)
                                                                                .ToList(),
                (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.Asc) => allPersons.OrderBy(temp => temp.ReceiveNewsLetters)
                                                                                .ToList(),

                (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.Desc) => allPersons.OrderByDescending(temp => temp.ReceiveNewsLetters)
                                                                                .ToList(),

                _ => allPersons
            };
            return sortedPersons;
        }

        public PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        {
            if (personUpdateRequest == null)
                throw new ArgumentNullException(nameof(Person));

            //validation
            ValidationHelper.ModelValidation(personUpdateRequest);

            //get matching person obj to update
            Person? matchingPerson =
                _persons./*Persons.*/FirstOrDefault(temp => temp.PersonID == personUpdateRequest.PersonID);

            if (matchingPerson == null)
            {
                throw new ArgumentException("Given person id doesnt exist");
            }

            //update all details
            matchingPerson.PersonName = personUpdateRequest.PersonName;
            matchingPerson.Email = personUpdateRequest.Email;
            matchingPerson.Address = personUpdateRequest.Address;
            matchingPerson.DateOfBirth = personUpdateRequest.DateOfBirth;
            matchingPerson.Gender = personUpdateRequest.Gender.ToString();
            matchingPerson.ReceiveNewsLetters = personUpdateRequest.ReceiveNewsLetters;

            /*_persons.SaveChanges();*/ //upd

            return ConvertPersonToPersonResponse(matchingPerson);

        }

        public bool DeletePerson(Guid? personId)
        {
            if (personId == null) throw new ArgumentNullException(nameof(personId));

            Person? person = _persons.FirstOrDefault(temp => temp.PersonID == personId);

            if (person == null) return false;

            _persons.RemoveAll(temp => temp.PersonID == personId);

            /*_persons.SaveChanges();*/

            return true;
        }
    }
}
