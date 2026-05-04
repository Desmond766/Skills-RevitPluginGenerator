---
kind: type
id: T:Autodesk.Revit.DB.ExtensibleStorage.Entity
source: html/cf17f0e8-33bd-ef95-bf4b-e6298406f29b.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.Entity

An object stored in the Extensible Storage framework. An Entity is described by a Schema,
 which serves both to identify an Entity, and to describe its contents (Fields).

## Syntax (C#)
```csharp
public class Entity : IDisposable
```

## Remarks
An Entity is similar to an object in most object-oriented languages, while a Schema is the
 class of that object.
The Get and Set methods are central - they provide access to the fields of the Entity.
Note that an unitialized Entity retrieved from an Element or another Entity (if it has not
 been created yet) will be represented as an invalid entity, not Nothing nullptr a null reference ( Nothing in Visual Basic) .
If an Element containing an Entity is split (e.g., a wall split), the Entity and its data will exist
 in both new Elements.
If an Element containing an Entity is copied, the Element copy will also contain a copy of the Entity and its data.
If an Entity stores an ElementId, and the Element with that ElementId is deleted, the stored
 ElementId will automatically be set to ElementId.InvalidElementId (-1).

