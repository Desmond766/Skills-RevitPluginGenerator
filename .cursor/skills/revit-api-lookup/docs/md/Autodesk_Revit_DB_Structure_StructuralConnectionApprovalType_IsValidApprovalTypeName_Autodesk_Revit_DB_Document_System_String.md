---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionApprovalType.IsValidApprovalTypeName(Autodesk.Revit.DB.Document,System.String)
source: html/4efb1275-c310-a4ee-34b2-55f1a07d10c4.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionApprovalType.IsValidApprovalTypeName Method

Verifies if the provided approval name is unique in the document.

## Syntax (C#)
```csharp
public static bool IsValidApprovalTypeName(
	Document doc,
	string name
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`)
- **name** (`System.String`)

## Returns
True if approval type name is unique.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

