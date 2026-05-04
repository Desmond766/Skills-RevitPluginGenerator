---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBendData.#ctor(Autodesk.Revit.DB.Structure.RebarBarType,Autodesk.Revit.DB.Structure.RebarHookType,Autodesk.Revit.DB.Structure.RebarHookType,Autodesk.Revit.DB.Structure.RebarStyle,Autodesk.Revit.DB.Structure.RebarHookOrientation,Autodesk.Revit.DB.Structure.RebarHookOrientation)
source: html/16e0ceff-fb53-cee7-c49d-8bbd85151869.htm
---
# Autodesk.Revit.DB.Structure.RebarBendData.#ctor Method

Constructs a new RebarBendData using the bar type, hook types, style and orientation values.

## Syntax (C#)
```csharp
public RebarBendData(
	RebarBarType barType,
	RebarHookType hookType0,
	RebarHookType hookType1,
	RebarStyle style,
	RebarHookOrientation hookOrient0,
	RebarHookOrientation hookOrient1
)
```

## Parameters
- **barType** (`Autodesk.Revit.DB.Structure.RebarBarType`)
- **hookType0** (`Autodesk.Revit.DB.Structure.RebarHookType`)
- **hookType1** (`Autodesk.Revit.DB.Structure.RebarHookType`)
- **style** (`Autodesk.Revit.DB.Structure.RebarStyle`)
- **hookOrient0** (`Autodesk.Revit.DB.Structure.RebarHookOrientation`)
- **hookOrient1** (`Autodesk.Revit.DB.Structure.RebarHookOrientation`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

