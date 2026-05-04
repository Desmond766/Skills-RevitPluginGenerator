---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.Duct.SetSystemType(Autodesk.Revit.DB.ElementId)
zh: 风管
source: html/a2a9376f-2dae-cc06-6066-c7b8a7789788.htm
---
# Autodesk.Revit.DB.Mechanical.Duct.SetSystemType Method

**中文**: 风管

Updates the associated system type for the duct.

## Syntax (C#)
```csharp
public void SetSystemType(
	ElementId systemTypeId
)
```

## Parameters
- **systemTypeId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the hvac system type.

## Remarks
If the duct previously did not have a system associated to it, this will create a new system.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The systemTypeId is not valid HVAC system type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

