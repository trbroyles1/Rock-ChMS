//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Data Transfer Object for Action object
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class ActionDto : IDto, DotLiquid.ILiquidizable
    {
        /// <summary />
        [DataMember]
        public int ActivityId { get; set; }

        /// <summary />
        [DataMember]
        public int ActionTypeId { get; set; }

        /// <summary />
        [DataMember]
        public DateTime? LastProcessedDateTime { get; set; }

        /// <summary />
        [DataMember]
        public DateTime? CompletedDateTime { get; set; }

        /// <summary />
        [DataMember]
        public int Id { get; set; }

        /// <summary />
        [DataMember]
        public Guid Guid { get; set; }

        /// <summary>
        /// Instantiates a new DTO object
        /// </summary>
        public ActionDto ()
        {
        }

        /// <summary>
        /// Instantiates a new DTO object from the entity
        /// </summary>
        /// <param name="action"></param>
        public ActionDto ( Action action )
        {
            CopyFromModel( action );
        }

        /// <summary>
        /// Creates a dictionary object.
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, object> ToDictionary()
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add( "ActivityId", this.ActivityId );
            dictionary.Add( "ActionTypeId", this.ActionTypeId );
            dictionary.Add( "LastProcessedDateTime", this.LastProcessedDateTime );
            dictionary.Add( "CompletedDateTime", this.CompletedDateTime );
            dictionary.Add( "Id", this.Id );
            dictionary.Add( "Guid", this.Guid );
            return dictionary;
        }

        /// <summary>
        /// Creates a dynamic object.
        /// </summary>
        /// <returns></returns>
        public virtual dynamic ToDynamic()
        {
            dynamic expando = new ExpandoObject();
            expando.ActivityId = this.ActivityId;
            expando.ActionTypeId = this.ActionTypeId;
            expando.LastProcessedDateTime = this.LastProcessedDateTime;
            expando.CompletedDateTime = this.CompletedDateTime;
            expando.Id = this.Id;
            expando.Guid = this.Guid;
            return expando;
        }

        /// <summary>
        /// Copies the model property values to the DTO properties
        /// </summary>
        /// <param name="model">The model.</param>
        public void CopyFromModel( IEntity model )
        {
            if ( model is Action )
            {
                var action = (Action)model;
                this.ActivityId = action.ActivityId;
                this.ActionTypeId = action.ActionTypeId;
                this.LastProcessedDateTime = action.LastProcessedDateTime;
                this.CompletedDateTime = action.CompletedDateTime;
                this.Id = action.Id;
                this.Guid = action.Guid;
            }
        }

        /// <summary>
        /// Copies the DTO property values to the entity properties
        /// </summary>
        /// <param name="model">The model.</param>
        public void CopyToModel ( IEntity model )
        {
            if ( model is Action )
            {
                var action = (Action)model;
                action.ActivityId = this.ActivityId;
                action.ActionTypeId = this.ActionTypeId;
                action.LastProcessedDateTime = this.LastProcessedDateTime;
                action.CompletedDateTime = this.CompletedDateTime;
                action.Id = this.Id;
                action.Guid = this.Guid;
            }
        }

        /// <summary>
        /// Converts to liquidizable object for dotLiquid templating
        /// </summary>
        /// <returns></returns>
        public object ToLiquid()
        {
            return this.ToDictionary();
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public static class ActionDtoExtension
    {
        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Action ToModel( this ActionDto value )
        {
            Action result = new Action();
            value.CopyToModel( result );
            return result;
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<Action> ToModel( this List<ActionDto> value )
        {
            List<Action> result = new List<Action>();
            value.ForEach( a => result.Add( a.ToModel() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<ActionDto> ToDto( this List<Action> value )
        {
            List<ActionDto> result = new List<ActionDto>();
            value.ForEach( a => result.Add( a.ToDto() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static ActionDto ToDto( this Action value )
        {
            return new ActionDto( value );
        }

    }
}