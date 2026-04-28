---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.Entity.#ctor(System.Guid)
source: html/28641ea2-3850-be59-ac96-1e668f4aa6bd.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.Entity.#ctor Method

Creates a new Entity corresponding to the Schema of the specified GUID.

## Syntax (C#)
```csharp
public Entity(
	Guid schemaGUID
)
```

## Parameters
- **schemaGUID** (`System.Guid`)

## Remarks
You can store the newly created Entity in an Element or in another Entity.
 If you do not have write access to the Schema, an exception will be thrown.
 If the GUID does not correspond to a known Schema, the Entity will be invalid
 and an exception will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The GUID does not correspond to any Schema in memory.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Writing of Entities of this Schema is not allowed to the current add-in.

