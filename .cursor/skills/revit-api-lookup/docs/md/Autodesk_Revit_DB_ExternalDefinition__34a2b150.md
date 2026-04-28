---
kind: type
id: T:Autodesk.Revit.DB.ExternalDefinition
source: html/a3e84415-b88e-a8e0-4e11-64795d92da0e.htm
---
# Autodesk.Revit.DB.ExternalDefinition

The ExternalDefinition object adds properties specific to Autodesk Revit shared parameter definitions.

## Syntax (C#)
```csharp
public class ExternalDefinition : Definition, 
	IDisposable
```

## Remarks
The ExternalDefinition object can be created by a definition Group object from a shared parameters file.
 External parameter definition must belong to a Group which is nothing more than a collection of shared
 parameter definitions. The following process should be followed to add a parameter to an
 element: Open the shared parameters file, via the Application.OpenSharedParameterFile() method.
 Access an existing or create a new group, via the DefinitionFile.Groups property. Access
 an existing or create a new external parameter definition, via the
 DefinitionGroup.Definitions property. Create a new Binding object with the categories to
 which the parameter will be bound using an InstanceBinding or a TypeBinding object. Finally
 add the binding and definition to the document using the Document.ParameterBindings object. Shared parameters added to elements are typically visible to interactive users. To add data to elements that
 is never visible to interactive users, use Extensible Storage to construct and populate the needed structured
 data.

