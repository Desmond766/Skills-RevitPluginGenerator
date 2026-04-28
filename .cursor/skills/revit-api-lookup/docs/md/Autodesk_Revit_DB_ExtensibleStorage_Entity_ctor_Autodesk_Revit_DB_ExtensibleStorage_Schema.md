---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.Entity.#ctor(Autodesk.Revit.DB.ExtensibleStorage.Schema)
source: html/ee435328-b63a-5bab-d8b2-bdc347c08aea.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.Entity.#ctor Method

Creates a new Entity corresponding to the Schema.

## Syntax (C#)
```csharp
public Entity(
	Schema schema
)
```

## Parameters
- **schema** (`Autodesk.Revit.DB.ExtensibleStorage.Schema`)

## Remarks
You can store the newly created Entity in an Element or in another Entity.
 If you do not have write access to the Schema, an exception will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Writing of Entities of this Schema is not allowed to the current add-in.

