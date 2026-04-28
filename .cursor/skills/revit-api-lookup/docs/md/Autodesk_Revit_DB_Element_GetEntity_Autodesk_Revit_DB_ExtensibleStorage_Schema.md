---
kind: method
id: M:Autodesk.Revit.DB.Element.GetEntity(Autodesk.Revit.DB.ExtensibleStorage.Schema)
zh: 构件、图元、元素
source: html/09d80bf1-c1d0-aa2e-4f18-e5a5e9c9d93f.htm
---
# Autodesk.Revit.DB.Element.GetEntity Method

**中文**: 构件、图元、元素

Returns the existing entity corresponding to the Schema if it has been saved in the
 Element, or an invalid entity otherwise.

## Syntax (C#)
```csharp
public Entity GetEntity(
	Schema schema
)
```

## Parameters
- **schema** (`Autodesk.Revit.DB.ExtensibleStorage.Schema`) - The Schema describing the Entity.

## Returns
The returned Entity.

## Remarks
The Entity that is returned is a copy of the stored data (with copy-on-write
 optimization). Modifying it is allowed (even with restricted write), but to save your
 changes you must call SetEntity.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Reading of Entities of this Schema is not allowed to the current add-in.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

