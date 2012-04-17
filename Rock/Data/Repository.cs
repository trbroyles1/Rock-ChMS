﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Rock.Data
{
    /// <summary>
    /// Repository for working with the Entity Framework
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> where T : Rock.Data.Model<T>
    {
        private DbContext _context;

        /// <summary>
        /// Gets the context.
        /// </summary>
        internal DbContext Context
        {
            get
            {
                if ( UnitOfWorkScope.CurrentObjectContext != null )
                    return UnitOfWorkScope.CurrentObjectContext;

                if ( _context == null )
                    _context = new RockContext();

                return _context;
            }
        }

        internal DbSet<T> _objectSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityRepository&lt;T&gt;"/> class.
        /// </summary>
        public Repository() :
            this( new RockContext() )
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityRepository&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="objectContext">The object context.</param>
        public Repository( DbContext objectContext )
        {
            _context = objectContext;
            _objectSet = Context.Set<T>();
        }

        /// <summary>
        /// An <see cref="IQueryable{T}"/> list of entitities
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> AsQueryable()                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
        {
            return _objectSet;
        }

        /// <summary>
        /// Gets the model with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual T Get( int id )
        {
            return FirstOrDefault( t => t.Id == id );
        }

        /// <summary>
        /// Gets the model by the public key.
        /// </summary>
        /// <param name="publicKey">The public key.</param>
        /// <returns></returns>
        public virtual T GetByPublicKey( string publicKey )
        {
            try
            {
                string identifier = Rock.Security.Encryption.DecryptString( publicKey );

                string[] idParts = identifier.Split( '>' );
                if ( idParts.Length == 2 )
                {
                    int id = Int32.Parse( idParts[0] );
                    Guid guid = new Guid( idParts[1] );

                    T model = Get( id );

                    if ( model != null && model.Guid.CompareTo( guid ) == 0 )
                        return model;
                }

                return null;
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// An <see cref="IEnumerable{T}"/> list of all entities
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _objectSet.ToList();
        }

        /// <summary>
        /// An <see cref="IEnumerable{T}"/> list of all entities that match the where clause
        /// </summary>
        /// <param name="where">
        /// <example>An example where clause: <c>t => t.Id == id</c></example>
        /// </param>
        /// <returns></returns>
        public virtual IEnumerable<T> Find( Expression<Func<T, bool>> where )
        {
            return _objectSet.Where( where );
        }

        /// <summary>
        /// Gets the only entity that matches the where clause
        /// </summary>
        /// <remarks>If more than one entity matches the where clause, and exception occurs</remarks>
        /// <param name="where">
        /// <example>An example where clause: <c>t => t.Id == id</c></example>
        /// </param>
        /// <returns></returns>
        public virtual T Single( Expression<Func<T, bool>> where )
        {
            return _objectSet.Single( where );
        }

        /// <summary>
        /// Get's the first entity that matches the where clause
        /// </summary>
        /// <remarks>If an entity that matches the where clause does not exist, an exception occurs</remarks>
        /// <param name="where">
        /// <example>An example where clause: <c>t => t.Id == id</c></example>
        /// </param>
        /// <returns></returns>
        public virtual T First( Expression<Func<T, bool>> where )
        {
            return _objectSet.First( where );
        }

        /// <summary>
        /// Get's the first entity that matches the where clause
        /// </summary>
        /// <remarks>If an entity that matches the where clause does not exist, a null value is returned</remarks>
        /// <param name="where">
        /// <example>An example where clause: <c>t => t.Id == id</c></example>
        /// </param>
        /// <returns></returns>
        public virtual T FirstOrDefault( Expression<Func<T, bool>> where )
        {
            return _objectSet.FirstOrDefault( where );
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual bool Add( T entity, int? personId )
        {
            bool cancel = false;
            entity.RaiseAddingEvent( out cancel, personId );
            if ( !cancel )
            {
                _objectSet.Add( entity );
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Attach( T entity )
        {
            _objectSet.Attach( entity );
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual bool Delete( T entity, int? personId )
        {
            bool cancel = false;
            entity.RaiseDeletingEvent( out cancel, personId );
            if ( !cancel )
            {
                _objectSet.Remove( entity );
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Saves the entity and returns a list of any entity changes that 
        /// need to be logged
        /// </summary>
        /// <param name="PersonId">The id of the person making the change</param>
        /// <returns></returns>
        public virtual void Save( T item, int? personId )
        {
            if ( item != null && item.Guid == Guid.Empty )
                item.Guid = Guid.NewGuid();

            var entityChanges = new List<Core.EntityChange>();

            Context.ChangeTracker.DetectChanges();

            List<object> addedEntities = new List<object>();
            List<object> deletedEntities = new List<object>();
            List<object> modifiedEntities = new List<object>();

            var contextAdapter = ( ( IObjectContextAdapter )Context );

            foreach ( ObjectStateEntry entry in contextAdapter.ObjectContext.ObjectStateManager.GetObjectStateEntries(
                System.Data.EntityState.Added | System.Data.EntityState.Deleted | System.Data.EntityState.Modified | System.Data.EntityState.Unchanged ) )
            {
                switch ( entry.State )
                {
                    case System.Data.EntityState.Added:

                        entityChanges.Concat( GetEntityChanges( entry.Entity, personId ) );

                        addedEntities.Add( entry.Entity );

                        if ( entry.Entity is IAuditable )
                        {
                            IAuditable auditable = ( IAuditable )entry.Entity;
                            auditable.CreatedByPersonId = personId;
                            auditable.CreatedDateTime = DateTime.Now;
                            auditable.ModifiedByPersonId = personId;
                            auditable.ModifiedDateTime = DateTime.Now;
                        }
                        break;

                    case System.Data.EntityState.Deleted:
                        deletedEntities.Add( entry.Entity );
                        break;

                    case System.Data.EntityState.Modified:

                        var model = entry.Entity as Model<T>;
                        if ( model != null )
                        {
                            bool cancel = false;
                            model.RaiseUpdatingEvent( out cancel, personId );
                            if ( cancel )
                            {
                                contextAdapter.ObjectContext.Detach( entry );
                            }
                            else
                            {
                                entityChanges.AddRange( GetEntityChanges( model, personId ) );

                                modifiedEntities.Add( entry.Entity );

                                if ( model is IAuditable )
                                {
                                    IAuditable auditable = ( IAuditable )model;
                                    auditable.ModifiedByPersonId = personId;
                                    auditable.ModifiedDateTime = DateTime.Now;
                                }
                            }
                        }

                        break;
                }
            }

            Context.SaveChanges();

            foreach ( object modifiedEntity in addedEntities )
            {
                var model = modifiedEntity as Model<T>;
                if (model != null)
                    model.RaiseAddedEvent( personId );
            }

            foreach ( object deletedEntity in deletedEntities )
            {
                var model = deletedEntity as Model<T>;
                if ( model != null )
                    model.RaiseDeletedEvent( personId );
            }

            foreach ( object modifiedEntity in modifiedEntities )
            {
                var model = modifiedEntity as Model<T>;
                if ( model != null )
                    model.RaiseUpdatedEvent( personId );
            }

            if ( entityChanges != null && entityChanges.Count > 0 )
            {
                Core.EntityChangeRepository entityChangeRepository = new Core.EntityChangeRepository();
                foreach ( Rock.Core.EntityChange entityChange in entityChanges )
                {
                    entityChangeRepository.Add( entityChange, personId );
                    entityChangeRepository.Save( entityChange, personId );
                }
            }
        }

        private List<Rock.Core.EntityChange> GetEntityChanges( object entity, int? personId )
        {
            List<Rock.Core.EntityChange> entityChanges = new List<Core.EntityChange>();

            // Do not track changes on the 'EntityChange' entity type. 
            if ( !( entity is Rock.Core.EntityChange ) )
            {
                Type entityType = entity.GetType();
                if ( entityType.Namespace == "System.Data.Entity.DynamicProxies" )
                    entityType = entityType.BaseType;

                Guid changeSet = Guid.NewGuid();

                // Look for properties that have the "TrackChanges" attribute
                foreach ( PropertyInfo propInfo in entity.GetType().GetProperties() )
                {
                    object[] customAttributes = propInfo.GetCustomAttributes( typeof( TrackChangesAttribute ), true );
                    if ( customAttributes.Length > 0 )
                    {
                        var currentValue = Context.Entry( entity ).Property( propInfo.Name ).CurrentValue;
                        var originalValue = Context.Entry( entity ).State != System.Data.EntityState.Added ?
                            Context.Entry( entity ).Property( propInfo.Name ).OriginalValue : string.Empty;

                        string currentValueStr = currentValue == null ? string.Empty : currentValue.ToString();
                        string originalValueStr = originalValue == null ? string.Empty : originalValue.ToString();

                        if ( currentValueStr != originalValueStr )
                        {
                            if ( entityChanges == null )
                                entityChanges = new List<Core.EntityChange>();

                            Rock.Core.EntityChange change = new Core.EntityChange();
                            change.ChangeSet = changeSet;
                            change.ChangeType = Context.Entry( entity ).State.ToString();
                            change.EntityType = entityType.Name;
                            change.Property = propInfo.Name;
                            change.OriginalValue = originalValueStr;
                            change.CurrentValue = currentValueStr;
                            change.CreatedByPersonId = personId;
                            change.CreatedDateTime = DateTime.Now;

                            entityChanges.Add( change );
                        }
                    }
                }
            }

            return entityChanges;
        }

        /// <summary>
        /// Reorders the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="oldIndex">The old index.</param>
        /// <param name="newIndex">The new index.</param>
        /// <param name="personId">The person id.</param>
        public virtual void Reorder( List<T> items, int oldIndex, int newIndex, int? personId )
        {
            T movedItem = items[oldIndex];
            items.RemoveAt( oldIndex );
            if ( newIndex >= items.Count )
                items.Add( movedItem );
            else
                items.Insert( newIndex, movedItem );

            int order = 0;
            foreach ( T item in items )
            {
                IOrdered orderedItem = item as IOrdered;
                if ( orderedItem != null )
                {
                    if ( orderedItem.Order != order )
                    {
                        orderedItem.Order = order;
                        Save( item, personId );
                    }
                }
                order++;
            }
        }

    }
}