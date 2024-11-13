import { Link } from "react-router-dom";
import { PiBookOpenTextLight } from "react-icons/pi";
import { BiUserCircle, BiShow } from "react-icons/bi";
import { AiOutlineEdit } from "react-icons/ai";
import { BsInfoCircle } from "react-icons/bs";
import { MdOutlineDelete } from "react-icons/md";
import { useState } from "react";
import BookModal from "./BookModal";

const BookSingleCard = ({ item }, key) => {
  const [showModal, setShowModal] = useState(false);

  return (
    <div
      key={item.id}
      className="border-2 border-gray-500 rounded-lg px-4 py-2 m-4 relative hover:shadow-xl"
    >
      <div className="w-1/6 w-fit">
        <h2 className="absolute top-1 right-2 px-3 py-1 bg-red-300 rounded-lg">
          {item.publishYear}
        </h2>
      </div>

      <div className="w-9/12">
        <h4 className="my-2 break-words">Id: {item.id}</h4>
      </div>
      <div className="flex justify-start items-center gap-x-2">
        <PiBookOpenTextLight className="text-red-300  text-2xl" />
        <h2 className="my-1">{item.title}</h2>
      </div>
      <div className="flex justify-start items-center gap-x-2" key={key}>
        <BiUserCircle className="text-red-300 text-2xl" />
        <h2 className="my-1">{item.author}</h2>
      </div>
      <div className="flex justify-between items-center gap-x-2 mt-4 p-4">
        <BiShow
          className="text-3xl text-blue-800 hover:text-black cursor-pointer"
          onClick={() => setShowModal(true)}
        />
        <Link to={`/books/details/${item.id}`}>
          <BsInfoCircle className="text-2xl text-green-800 hover:text-black" />
        </Link>
        <Link to={`/books/edit/${item.id}`}>
          <AiOutlineEdit className="text-2xl text-blue-800 hover:text-black" />
        </Link>
        <Link to={`/books/delete/${item.id}`}>
          <MdOutlineDelete className="text-2xl text-red-800 hover:text-black" />
        </Link>
      </div>
      {showModal && (
        <BookModal item={item} onClose={() => setShowModal(false)} />
      )}
    </div>
  );
};

export default BookSingleCard;