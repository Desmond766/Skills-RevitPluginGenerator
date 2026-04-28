---
kind: method
id: M:Autodesk.Revit.DB.Structure.ExtElemChangeBeamSectionRegistry.RegisterInterface(Autodesk.Revit.DB.Structure.IExtElemChangeBeamSection)
source: html/6b58fc3e-d1c1-780b-5aec-b2a985f01939.htm
---
# Autodesk.Revit.DB.Structure.ExtElemChangeBeamSectionRegistry.RegisterInterface Method

Registers a IExtElemChangeBeamSection

## Syntax (C#)
```csharp
public static void RegisterInterface(
	IExtElemChangeBeamSection provider
)
```

## Parameters
- **provider** (`Autodesk.Revit.DB.Structure.IExtElemChangeBeamSection`) - IExtElemChangeBeamSection to be registered.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The provider object is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is already registered Connections Provider.

