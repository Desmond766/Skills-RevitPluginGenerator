---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ConduitSizeSettings.AddSize(System.String,Autodesk.Revit.DB.Electrical.ConduitSize)
source: html/dcb1141a-656d-31fd-7e04-e2ffe12da313.htm
---
# Autodesk.Revit.DB.Electrical.ConduitSizeSettings.AddSize Method

Inserts a new ConduitSize in to the conduit size settings. The conduit standard name determines the location of the new size in the size table.

## Syntax (C#)
```csharp
public void AddSize(
	string standardName,
	ConduitSize sizeInfo
)
```

## Parameters
- **standardName** (`System.String`) - The conduit standard name.
- **sizeInfo** (`Autodesk.Revit.DB.Electrical.ConduitSize`) - The new ConduitSize to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The conduit standard name does not exist.
 -or-
 The conduit size already exists.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The function is called during iterating the size set.

