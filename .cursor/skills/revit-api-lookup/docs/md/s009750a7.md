---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightFamily.GetLightFamily(Autodesk.Revit.DB.Document)
source: html/d892c779-26f3-5b33-c701-d57e676f7317.htm
---
# Autodesk.Revit.DB.Lighting.LightFamily.GetLightFamily Method

Creates a light family object from the given family document

## Syntax (C#)
```csharp
public static LightFamily GetLightFamily(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The family document

## Returns
The newly created LightFamily object

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The Document is the argument that is being validated
 The document is not valid because it is not a light family document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

