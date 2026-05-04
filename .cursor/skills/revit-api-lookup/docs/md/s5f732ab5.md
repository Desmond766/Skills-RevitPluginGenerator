---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightType.SetInitialColor(Autodesk.Revit.DB.Lighting.InitialColor)
source: html/cb6977dd-71bc-7271-fda0-0c72c8e45d38.htm
---
# Autodesk.Revit.DB.Lighting.LightType.SetInitialColor Method

Replace the current initial color object with the given object

## Syntax (C#)
```csharp
public void SetInitialColor(
	InitialColor initialColor
)
```

## Parameters
- **initialColor** (`Autodesk.Revit.DB.Lighting.InitialColor`) - An object derived from an InitialColor object
 The object pointed to is cloned internally

## Remarks
The argument object is cloned

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

