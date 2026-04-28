---
kind: type
id: T:Autodesk.Revit.DB.ExtensibleStorage.Schema
source: html/9817e7db-8367-ea4e-1769-0488f3faa37f.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.Schema

The description of a single object (Entity) in the Extensible Storage framework. Contains
 identity information, documentation and the list of fields to be stored in the Entity.

## Syntax (C#)
```csharp
public class Schema : IDisposable
```

## Remarks
A Schema is similar to a class in most object-oriented languages, or to a C struct,
 while an Entity is an object of that class.
The Schema object is immutable. To create and populate a Schema, use the SchemaBuilder
 class. Schemas are stored in the memory of the running instance of Revit and may be
 retrieved with the Lookup method.
When a document containing Entities of a Schema is saved, the Schema is saved with the
 document too. Opening that document reintroduces the Schema into memory.
As you plan to store your data in Revit, please be aware that the data will be
 stored in Revit elements. Overwhelming the Revit database will impact performance and
 stability, and will make the user unhappy. Also, remember that multiple add-ins may be
 storing their data simultaneously. Several kB per element or several MB per file
 are reasonable maximums for one add-in. If you have larger requirements, consider storing
 them in a separate database (such as SQLite) and storing keys into that database in Revit.

