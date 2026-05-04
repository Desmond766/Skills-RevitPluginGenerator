---
kind: method
id: M:Autodesk.Revit.DB.AssemblyInstance.AreElementsValidForAssembly(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.ElementId)
source: html/b86d920d-dd9e-db71-c650-cdfbf623942d.htm
---
# Autodesk.Revit.DB.AssemblyInstance.AreElementsValidForAssembly Method

Identifies if provided assembly members are valid.

## Syntax (C#)
```csharp
public static bool AreElementsValidForAssembly(
	Document document,
	ICollection<ElementId> assemblyMemberIds,
	ElementId assemblyId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **assemblyMemberIds** (`System.Collections.Generic.ICollection < ElementId >`) - Element ids to be tested for validity for membership of an assembly instance.
- **assemblyId** (`Autodesk.Revit.DB.ElementId`) - Id of the existing assembly to add components to. If invalid, the method return whether the components can be added to a new assembly

## Returns
True if all member ids are valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

