---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.FluidType.GetFluidType(Autodesk.Revit.DB.Document,System.String)
source: html/18596b04-d15b-c946-8a71-53914510476e.htm
---
# Autodesk.Revit.DB.Plumbing.FluidType.GetFluidType Method

Gets a fluid type by name.

## Syntax (C#)
```csharp
public static FluidType GetFluidType(
	Document document,
	string fluidTypeName
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **fluidTypeName** (`System.String`) - The name of fluid type.

## Returns
The fluid type. Nothing nullptr a null reference ( Nothing in Visual Basic) if the fluid type was not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

