---
kind: method
id: M:Autodesk.Revit.DB.Element.DeleteEntity(Autodesk.Revit.DB.ExtensibleStorage.Schema)
zh: 构件、图元、元素
source: html/ef0fa7d8-8152-6300-285d-1c0cdc08e5a7.htm
---
# Autodesk.Revit.DB.Element.DeleteEntity Method

**中文**: 构件、图元、元素

Deletes the existing entity created by %schema% in the element

## Syntax (C#)
```csharp
public bool DeleteEntity(
	Schema schema
)
```

## Parameters
- **schema** (`Autodesk.Revit.DB.ExtensibleStorage.Schema`) - Schema used for creation of the entity

## Returns
True if entity was deleted, false if entity didn't exist

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Writing of Entities of this Schema is not allowed to the current add-in.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

