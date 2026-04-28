---
kind: method
id: M:Autodesk.Revit.DB.GlobalParametersManager.AreGlobalParametersAllowed(Autodesk.Revit.DB.Document)
source: html/0191434b-d8c8-ed25-c81b-2679e8201460.htm
---
# Autodesk.Revit.DB.GlobalParametersManager.AreGlobalParametersAllowed Method

Tests whether global parameters are allowed in the given document.

## Syntax (C#)
```csharp
public static bool AreGlobalParametersAllowed(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - A revit document of interest.

## Remarks
First of all, global parameters can be had in main project documents only;
 they are not supported in family documents. However, there may also be other
 circumstances due to which global parameters may be disallowed in a particular
 project, either temporarily or permanently.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

