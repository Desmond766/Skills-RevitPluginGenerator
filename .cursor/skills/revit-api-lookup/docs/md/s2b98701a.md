---
kind: method
id: M:Autodesk.Revit.DB.Structure.ReinforcementSettings.GetReinforcementSettings(Autodesk.Revit.DB.Document)
source: html/870cbfee-b1d4-0dd8-3e14-4802f3eafd25.htm
---
# Autodesk.Revit.DB.Structure.ReinforcementSettings.GetReinforcementSettings Method

Obtains the ReinforcementSettings object for the specified project document.

## Syntax (C#)
```csharp
public static ReinforcementSettings GetReinforcementSettings(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - A project document.

## Returns
The ReinforcementSettings object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

