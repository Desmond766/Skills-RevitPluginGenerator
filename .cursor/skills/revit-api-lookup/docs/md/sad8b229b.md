---
kind: method
id: M:Autodesk.Revit.DB.AssemblyInstance.CanRemoveElementsFromAssembly(Autodesk.Revit.DB.AssemblyInstance,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/6eadcc05-6ac5-81f4-79ee-4893a050d34b.htm
---
# Autodesk.Revit.DB.AssemblyInstance.CanRemoveElementsFromAssembly Method

Identifies if provided assembly members can be removed from the assembly instance.

## Syntax (C#)
```csharp
public static bool CanRemoveElementsFromAssembly(
	AssemblyInstance assemblyInstance,
	ICollection<ElementId> memberIds
)
```

## Parameters
- **assemblyInstance** (`Autodesk.Revit.DB.AssemblyInstance`) - The assembly instance to remove elements from.
- **memberIds** (`System.Collections.Generic.ICollection < ElementId >`) - Element ids to be tested for validity to remove from the assembly instance.

## Returns
True if all member ids are valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

