---
kind: method
id: M:Autodesk.Revit.DB.ParameterUtils.DownloadParameter(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ParameterDownloadOptions,Autodesk.Revit.DB.ForgeTypeId)
source: html/6449c1fe-90af-e6d4-e852-91f6eeae5c97.htm
---
# Autodesk.Revit.DB.ParameterUtils.DownloadParameter Method

Create a shared parameter element in the given document according to a parameter definition downloaded from the Parameters Service.

## Syntax (C#)
```csharp
public static SharedParameterElement DownloadParameter(
	Document document,
	ParameterDownloadOptions options,
	ForgeTypeId parameterTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document in which to create a shared parameter from a downloaded definition.
- **options** (`Autodesk.Revit.DB.ParameterDownloadOptions`) - Parameter download options.
- **parameterTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Parameter identifier.

## Returns
The shared parameter instance.

## Remarks
The identifier of a user-defined parameter definition on the Parameters Service has the form
 "parameters.<accountId>:<schemaId>-<versionNumber>", where <versionNumber> is a
 semantic version number such as "1.0.0" and <accountId> and <schemaId> are GUIDs consisting of
 32 hexadecimal digits. Revit will extract the <schemaId> GUID to identify the shared parameter
 element. If a shared parameter with a matching GUID is not yet present in the document, this method will attempt
 to obtain the parameter and apply the given bindings. If the parameter definition is already available
 locally, Revit will use the local definition. Otherwise, Revit will attempt to download the requested
 parameter definition from the Parameters Service. The given document may be either a project or a family document. The rules for adding parameters to
 project and family documents differ. For family documents, requesting a parameter with a GUID matching that of a shared parameter already
 present in the family document is an error. Family parameters must have unique names. There is an error if the target document is a family and the
 downloaded parameter is found to have a name that matches that of a parameter already present in the family
 document. Family parameters must be initialized to a default value. There is an error if the target document is a
 family and the downloaded parameter is a Family Type parameter and no family of the requisite category
 exists in the family document. When the target document is a project, if a parameter exactly matching the given ForgeTypeId is already
 present in the document, this method will not download anything. Otherwise, if a local shared parameter with
 a GUID colliding with the given ForgeTypeId is already present in the project document, this method will
 download the requested parameter from the Parameters Service, validate that the requested parameter is
 compatible with the existing local definition, and overwrite the existing local definition according to the
 downloaded definition. Attempting to download an incompatible definition that collides with an existing
 local shared parameter is an error. If the parameter or a compatible local parameter is already present in
 the target project document, this method will update the existing parameter's bindings according to the
 given bindings. When updating bindings, new category bindings may be added to the existing parameter but
 existing category bindings will not be removed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the parameter identifier does not include a GUID, when required bindings are not assigned, when
 the requested group identifier does not identify a group that accommodates user-defined parameters, when a
 parameter with a matching GUID is already present in the given family document, when the given project
 document already contains an incompatible parameter definition with the same GUID, or when a parameter with
 a matching name is already present in the given family document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DefaultValueException** - Thrown when the target document is a family and the downloaded parameter is a Family Type parameter and no
 family of the requisite category exists in the family document.
- **Autodesk.Revit.Exceptions.NetworkCommunicationException** - Thrown when communication with the Parameters Service is unsuccessful.
- **Autodesk.Revit.Exceptions.ResourceNotFoundException** - Thrown when the requested parameter definition is not found on the Parameters Service.
- **Autodesk.Revit.Exceptions.SchemaException** - Thrown when there is an error interpreting a downloaded parameter definition.

