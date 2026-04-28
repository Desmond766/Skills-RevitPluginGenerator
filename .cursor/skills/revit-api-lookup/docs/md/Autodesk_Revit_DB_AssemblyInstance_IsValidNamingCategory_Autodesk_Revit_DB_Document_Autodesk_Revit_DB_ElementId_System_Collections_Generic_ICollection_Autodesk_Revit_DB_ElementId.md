---
kind: method
id: M:Autodesk.Revit.DB.AssemblyInstance.IsValidNamingCategory(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/787779c8-a2ed-d7c4-5cf2-0cc5c20de50e.htm
---
# Autodesk.Revit.DB.AssemblyInstance.IsValidNamingCategory Method

Identifies if the naming category is valid for an assembly instance.

## Syntax (C#)
```csharp
public static bool IsValidNamingCategory(
	Document document,
	ElementId namingCategoryId,
	ICollection<ElementId> assemblyMemberIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document for the assembly instance.
- **namingCategoryId** (`Autodesk.Revit.DB.ElementId`) - The id of the naming category for the assembly instance.
- **assemblyMemberIds** (`System.Collections.Generic.ICollection < ElementId >`) - Member ids to check validity of naming category

## Returns
True if the naming category is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

