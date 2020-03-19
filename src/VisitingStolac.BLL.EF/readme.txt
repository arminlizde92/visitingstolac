The actual implementation of the whole logic of the application

Folders:
MapperProfiles: All Entities need to have a MapperProfile. A mapper profile class needs to inherti from the class 
                AutoMapper.Profile. Keep the clode clean like in the examples. The configuration for the injection 
                of the mapper profile is already taken care of, so no need to do something about that.
Repositories:   The actual implementation of the logic takes places in the repositories. Before creating a repository
                we need to register the entity as a DBSet (which is basically another repository inside our repository)
                in the VisitingStolacDBContext.cs in the DAL project.
UOW:            After the implementation of the repository we need to add the new repository to the UOW which will be used in
                the controllers.