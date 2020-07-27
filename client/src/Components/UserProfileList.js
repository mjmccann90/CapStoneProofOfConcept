import React, { useContext, useEffect } from "react";
import { UserProfileContext } from "../DataProviders/UserProfileProvider";

const UserProfileList = () => {
  const { userProfiles, getAllUserProfiles } = useContext(UserProfileContext);

  useEffect(() => {
    getAllUserProfiles();
  }, []);

  return (
    <div>
      {userProfiles.map((userProfile) => (
        <div key={userProfile.id}>
          <p>
            <strong>{userProfile.Name}</strong>
          </p>
          <p>{userProfile.Email}</p>
          <p>{userProfile.PersonalityType}</p>

        </div>
      ))}
    </div>
  );
};

export default UserProfileList;