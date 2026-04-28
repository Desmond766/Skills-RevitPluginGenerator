---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.Schema.GetField(System.String)
source: html/e706cd01-bc50-9a3c-68c1-9bd4507c85e0.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.Schema.GetField Method

Gets a Field of a given name from the Schema.

## Syntax (C#)
```csharp
public Field GetField(
	string name
)
```

## Parameters
- **name** (`System.String`) - The Field name

## Returns
The Field

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Reading of Entities of this Schema is not allowed to the current add-in.

